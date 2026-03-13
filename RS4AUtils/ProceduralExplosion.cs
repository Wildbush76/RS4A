using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;

namespace RS4A.RS4AUtils
{
    internal class ProceduralExplosion
    {
        private readonly PriorityQueue<Tuple<int, int, Tile>, double> tilesToExplode = new();
        private int dequeuePerTick;
        private Vector2 center;
        private static readonly Random random = new();



        /// <summary>
        /// How many layers of the crater should be dedicated to the block replacmenet
        /// </summary>
        public int CraterLayers
        {
            init;
            get;
        }

        private int CrateringRadius
        {
            get => BlastRadius - CraterLayers;
        }

        public int[] CrateringTiles
        {
            init;
            get;
        }

        public string[] DeathMessages { init; get; }



        public int DamageRadius { init; get; } = 80;
        public int MaxDamage { init; get; } = 0;
        public int ExplosionTime { init; get; } = 60;
        public bool Exploding { private set; get; } = false;
        public int BlastRadius { init; get; } = 10;


        public void InitExplosion(Vector2 center)
        {
            this.center = center;

            center /= 16;

            int minX = (int)(center.X) - BlastRadius;
            int maxX = (int)(center.X) + BlastRadius;
            int minY = (int)(center.Y) - BlastRadius;
            int maxY = (int)(center.Y) + BlastRadius;

            Utils.ClampWithinWorld(ref minX, ref minY, ref maxX, ref maxY);

            tilesToExplode.EnsureCapacity((maxX - minX) * (maxY - minY));

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    double distance = center.Distance(new Vector2(x, y));

                    Tile currentTile = Framing.GetTileSafely(x, y);
                    if (distance < BlastRadius)
                        tilesToExplode.Enqueue(new(x, y, currentTile), distance);

                }
            }
            EntityDamage();
            dequeuePerTick = Math.Max(tilesToExplode.Count / ExplosionTime, 1);
            Exploding = true;
        }




        private void EntityDamage()
        {
            foreach (Player player in Main.player)
            {
                if (!player.active)
                    continue;

                float distance = player.Center.Distance(center);

                if (distance <= DamageRadius)
                {
                    NetworkText deathMessage = NetworkText.FromKey(DeathMessages[random.Next(0, DeathMessages.Length)], player.name);
                    player.Hurt(PlayerDeathReason.ByCustomReason(deathMessage), EntityDamage(distance), 0, dodgeable: false, knockback: 0);
                }

            }

            foreach (NPC npc in Main.npc)
            {
                if (!npc.active)
                    continue;

                float distance = npc.Center.Distance(center);

                NPC.HitInfo info = new()
                {
                    Damage = EntityDamage(distance),
                    Knockback = 0
                };

                npc.StrikeNPC(info);
            }

        }

        private int EntityDamage(float distance)
        {
            return Math.Min((int)(Math.Pow(1 - distance / DamageRadius, 2) * MaxDamage), MaxDamage);
        }



        public bool ProcessExplosion()
        {
            WorldGen.gen = true;
            for (int i = 0; i < dequeuePerTick; i++)
            {
                if (!tilesToExplode.TryDequeue(out var t, out double distance))
                {
                    return true;
                }
                Tile tile = t.Item3;

                if (tile.HasTile)
                {
                    DestroyOrReplace(t.Item1, t.Item2, distance);
                }
                if (tile.WallType != WallID.None)
                {
                    WorldGen.KillWall(t.Item1, t.Item2);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.TileManipulation, number: 2, number2: t.Item1, number3: t.Item2, number4: 0);
                }
            }
            WorldGen.gen = false;   
            return false;
        }

        private void DestroyOrReplace(int x, int y, double distance)
        {
           
            if (distance > CrateringRadius)
            {
                double replaceChance = Math.Sqrt((distance - CrateringRadius) / (CraterLayers));
                if (random.NextDouble() < replaceChance)
                {

                    if (CrateringTiles.Length > 0 && random.NextDouble() < (1 - replaceChance))
                    {
                        return;// dont destroy
                    }

                    WorldGen.KillTile(x, y, false, false, true);
                    WorldGen.PlaceTile(x, y, CrateringTiles[Main.rand.Next(0, CrateringTiles.Length)], true);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.TileManipulation, number: 4, number2: x, number3: y, number4: 0);
                          
                    return;
                }
            }
            WorldGen.KillTile(x, y, false, false, true);

        }

       


    }
}
