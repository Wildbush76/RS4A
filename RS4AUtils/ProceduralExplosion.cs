using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace RS4A.RS4AUtils
{
    internal class ProceduralExplosion
    {
        private readonly int blastRadius;
        private readonly PriorityQueue<Tuple<int, int, Tile>, double> tilesToExplode = new();
        private readonly int dequeuePerTick;
        private readonly Vector2 center;


        /// <summary>
        /// How many layers of the crater should be dedicated to the block replacmenet
        /// </summary>
        public int CrateringSize
        {
            init => field = blastRadius - value;
            get => field;
        }

        public int[] CrateringTiles
        {
            init;
            get;
        }

        public int DamageRadius { init; get; }
        public int MaxDamage { init; get; }


        public ProceduralExplosion(Vector2 center, int blastRadius, int explosionTime)
        {
            this.center = center;
            this.blastRadius = blastRadius;

            InitExplosion(center, blastRadius);
            dequeuePerTick =  Math.Max(tilesToExplode.Count / explosionTime,1);
        }

        private void InitExplosion(Vector2 center, int blastRadius)
        {
            int minX = (int)(center.X / 16) - blastRadius;
            int maxX = (int)(center.X / 16) + blastRadius;
            int minY = (int)(center.Y / 16) - blastRadius;
            int maxY = (int)(center.Y / 16) + blastRadius;

            Utils.ClampWithinWorld(ref minX, ref maxX, ref minY, ref maxY);

            tilesToExplode.EnsureCapacity((maxX - minX) * (maxY - minY));

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    double distance = Math.Sqrt(x * x + y * y);
                    Tile currentTile = Framing.GetTileSafely(x, y);
                    if (distance < blastRadius)
                    {
                        tilesToExplode.Enqueue(new(x, y, currentTile), distance);
                    }
                }
            }
            EntityDamage();
        }




        private void EntityDamage()
        {
            foreach (Player player in Main.player)
            {
                if (!player.active)
                    continue;

                float distance = player.Center.Distance(center);
                if (distance <= DamageRadius)
                    player.Hurt(PlayerDeathReason.LegacyEmpty(), EntityDamage(distance), 0, dodgeable: false, knockback: 0);
            }

            foreach(NPC npc in Main.npc) {
                if (!npc.active)
                    continue;
                
                float distance = npc.Center.Distance(center);

                NPC.HitInfo info = new() {
                    Damage = EntityDamage(distance),
                    Knockback = 0 };

                npc.StrikeNPC(info);
            }

        }

        private int EntityDamage(float distance)
        {
            return (int)(Math.Pow(1 - distance / DamageRadius, 2) * MaxDamage);
        }



        public bool ProcessExplosion()
        {
            for (int i = 0; i < dequeuePerTick; i++)
            {

                if (!tilesToExplode.TryDequeue(out var t, out double distance))
                {
                    return true;
                }
                Tile tile = t.Item3;


                if (tile.HasTile)
                {
                    if (distance > CrateringSize)
                    {
                        double replaceChance = Math.Sqrt((distance - CrateringSize) / (CrateringSize - blastRadius));

                        if (Main.rand.Next() < replaceChance)
                        {

                            if (CrateringTiles.Length > 0 || Main.rand.Next() > (1 - replaceChance))
                            {
                                continue;
                            }

                            WorldGen.KillTile(t.Item1, t.Item2, false, false, true);
                            WorldGen.PlaceTile(t.Item1, t.Item2, CrateringTiles[Main.rand.Next(0, CrateringTiles.Length)], true);
                        }

                    }
                    else
                        WorldGen.KillTile(t.Item1, t.Item2, false, false, true);

                }
                if (tile.WallType != WallID.None)
                {
                    WorldGen.KillWall(t.Item1, t.Item2);
                }
            }
            return false;
        }


    }
}
