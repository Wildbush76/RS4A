
using RS4A.Systems;
using RS4A.Tiles;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Projectiles
{
    public class HydrogenBombProjectile : ModProjectile
    {
        private const int blastRadius = 140;//includes the burnt block radius
        private const int burntBlockLayers = blastRadius - 20;
        private const float playerDamageRadius = 180 * 8;
        private const int maxDamage = 9999999;
        private readonly int[] craterTiles = [ModContent.TileType<RadioactiveStone>()];

        private readonly PriorityQueue<Tuple<int,int,Tile>, double> tilesToExplode = new();

        private int explosionCountdown = 180;
        private const int explosionTime = 60;//measured in ticks 60 per second
        private int dequeuePerTick = 0;
        private readonly Random random = new();


        public override void SetDefaults()
        {
            Projectile.damage = 500;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 32;
            Projectile.height = 16;
            Projectile.aiStyle = ProjAIStyleID.Explosive;
            Projectile.penetrate = 1;
            tilesToExplode.EnsureCapacity((int)Math.Round(Math.PI * blastRadius * blastRadius));
        }


        public override bool PreAI()
        {
            if (explosionCountdown > 0) {
                explosionCountdown--;
                if (explosionCountdown == 0)
                    StartExplosion();
                return true;
            }

            ProcessExplosion();
            return false;
        }

        private void ProcessExplosion() {
    
            for (int i = 0; i < dequeuePerTick; i++)
            {
            
                if (!tilesToExplode.TryDequeue(out var t, out double distance))
                {
                    Projectile?.Kill();
                    return;
                }
                Tile tile = t.Item3;


                if (tile.HasTile) {
                    WorldGen.KillTile(t.Item1, t.Item2, false, false, true);
                    if (distance > burntBlockLayers) {
                        int replaceChance = (int)(Math.Sqrt(blastRadius - distance ));
                        if (random.Next(0, replaceChance) == 0) {
                            WorldGen.PlaceTile(t.Item1, t.Item2, craterTiles[random.Next(0, craterTiles.Length)], true);
                        }
                    }
                }
                if (tile.WallType != 0)
                {
                    WorldGen.KillWall(t.Item1, t.Item2);
                }
            }

        }

    
        private void StartExplosion()
        {
            NuclearFlash.TriggerFlash();
            SoundEngine.PlaySound(SoundID.Item14, Projectile.Center);//Replace this with a dedicated sound
            Projectile.hide = true;
            for (int x = -blastRadius; x <= blastRadius; x++)
            {
                for (int y = -blastRadius; y <= blastRadius; y++)
                {
                    int xPosition = (int)(x + Projectile.Center.X / 16.0f);
                    int yPosition = (int)(y + Projectile.Center.Y / 16.0f);
                   
                    double distance = Math.Sqrt(x * x + y * y);
                    Tile currentTile = Framing.GetTileSafely(xPosition, yPosition);
                    if (distance < blastRadius)
                    {
                        tilesToExplode.Enqueue(new(xPosition,yPosition,currentTile), distance);
                    }
                }
            }
            dequeuePerTick = tilesToExplode.Count / explosionTime;
        }
    }
}
