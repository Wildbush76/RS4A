﻿using Microsoft.Xna.Framework;
using System;
using System.Net;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;

namespace RS4A.RS4AUtils
{
    internal class Explode
    {
        /// <summary>
        /// Creates an explosion with a cratering effects
        /// crater radius is how many layers of the outside of the crater should have the cratering effect
        /// </summary>
        /// <param name="center">the center of the explosion</param>
        /// <param name="maxDamage">the max damage the explosion will do. set to 0 if you do not want to deal damage</param>
        /// <param name="blastRadius">the radius that explosion effects</param>
        /// <param name="craterRadius">how many of the outside layers should have the cratering</param>
        /// <param name="craterTiles">list of tiles to use when cratering</param>
        /// <param name="deathMessages">death messages to display if a player is killed</param>
        /// <param name="debuffOnHit">what debuff will be applied on hit. set to 0 for none</param>
        /// <param name="duration">how long the debuff will last for.</param>
        public static void CrateringExplosion(Vector2 center, int maxDamage, int blastRadius, int craterRadius, int[] craterTiles, string[] deathMessages, int debuffOnHit, int duration)
        {
            SoundEngine.PlaySound(SoundID.Item14, center);
            Random random = new();
            for (int x = -blastRadius; x <= blastRadius; x++)
            {
                for (int y = -blastRadius; y <= blastRadius; y++)
                {
                    int xPosition = (int)(x + center.X / 16.0f);
                    int yPosition = (int)(y + center.Y / 16.0f);
                    double distance = Math.Sqrt(x * x + y * y);
                    Tile currentTile = Framing.GetTileSafely(xPosition, yPosition);
                    if (distance < blastRadius)
                    {

                        if (distance > blastRadius - craterRadius)
                        {

                            int replaceChance = (int)((distance - (blastRadius - craterRadius)) / 2) + 1;
                            if (random.Next(0, replaceChance) == 0)
                            {
                                if (currentTile.HasTile)
                                {
                                    WorldGen.KillTile(xPosition, yPosition, false, false, true);
                                    WorldGen.PlaceTile(xPosition, yPosition, craterTiles[random.Next(0, craterTiles.Length)], true);
                                }
                                if (currentTile.WallType != 0)
                                {
                                    WorldGen.KillWall(xPosition, yPosition);
                                }
                            }
                        }
                        else
                        {
                            if (currentTile.HasTile)
                            {
                                WorldGen.KillTile(xPosition, yPosition, false, false, true);
                            }
                            if (currentTile.WallType != 0)
                            {
                                WorldGen.KillWall(xPosition, yPosition);
                            }
                        }
                        Dust.NewDust(new Vector2(xPosition, yPosition), 22, 22, DustID.FlameBurst, 0.0f, 0.0f, 120, new Color(), 1f);
                    }
                }

            }

            //damage players
            for (int player = 0; player < Main.maxPlayers; player++)
            {
                Player targetPlayer = Main.player[player];
                if (targetPlayer.active && !targetPlayer.dead)
                {
                    float distance = targetPlayer.Distance(center);
                    float damageRadius = blastRadius * 16;
                    if (distance < damageRadius)
                    {
                        if (maxDamage > 0)
                        {
                            targetPlayer.Hurt(PlayerDeathReason.ByCustomReason(targetPlayer.name + deathMessages[random.Next(deathMessages.Length)]), CalculateDamageFromDistance(maxDamage,damageRadius,distance), 1, dodgeable: false);
                        }
                        if (debuffOnHit != 0)
                        {
                            targetPlayer.AddBuff(debuffOnHit, duration);
                        }
                    }
                }
            }

            foreach (NPC npc in Main.npc)
            {
                float distance = (npc.Distance(center));
                if (distance / 16 <= blastRadius)
                {
                    //npc.StrikeNPC(npc.CalculateHitInfo(damage, 1, false, 0));
                    NetMessage.SendStrikeNPC(npc, npc.CalculateHitInfo(CalculateDamageFromDistance(maxDamage,blastRadius * 16,distance), 1, false, 0));
                }
            }

        }

        public static int CalculateDamageFromDistance(int maxDamage, float damageRadius, float distance) {
            return (int)((damageRadius - distance) / damageRadius * maxDamage);
        }
        public static void CrateringExplosion(Vector2 center, int maxDamage, int blastRadius, int craterRadius, int[] craterTiles, string[] deathMessages)
        {
            CrateringExplosion(center, maxDamage, blastRadius, craterRadius, craterTiles, deathMessages, 0, 0);
        }

        public static void Explosion(Projectile projectile, int explosionRadius, int damage, bool damageAll, string[] deathMessages)
        {
            // Play explosion sound
            SoundEngine.PlaySound(SoundID.Item14, projectile.position);
            // Smoke Dust spawn
            for (int i = 0; i < 50; i++)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.Smoke, 0f, 0f, 100, default, 2f);
                dust.velocity *= 1.4f;
            }

            // Fire Dust spawn
            for (int i = 0; i < 80; i++)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.Torch, 0f, 0f, 100, default, 3f);
                dust.noGravity = true;
                dust.velocity *= 5f;
                dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.Torch, 0f, 0f, 100, default, 2f);
                dust.velocity *= 3f;
            }

            // Large Smoke Gore spawn
            for (int g = 0; g < 2; g++)
            {
                var goreSpawnPosition = new Vector2(projectile.position.X + projectile.width / 2 - 24f, projectile.position.Y + projectile.height / 2 - 24f);
                Gore gore = Gore.NewGoreDirect(projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                gore.scale = 1.5f;
                gore.velocity.X += 1.5f;
                gore.velocity.Y += 1.5f;
                gore = Gore.NewGoreDirect(projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                gore.scale = 1.5f;
                gore.velocity.X -= 1.5f;
                gore.velocity.Y += 1.5f;
                gore = Gore.NewGoreDirect(projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                gore.scale = 1.5f;
                gore.velocity.X += 1.5f;
                gore.velocity.Y -= 1.5f;
                gore = Gore.NewGoreDirect(projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                gore.scale = 1.5f;
                gore.velocity.X -= 1.5f;
                gore.velocity.Y -= 1.5f;
            }

            if (projectile.owner == Main.myPlayer)
            {

                int minTileX = (int)(projectile.Center.X / 16f - explosionRadius);
                int maxTileX = (int)(projectile.Center.X / 16f + explosionRadius);
                int minTileY = (int)(projectile.Center.Y / 16f - explosionRadius);
                int maxTileY = (int)(projectile.Center.Y / 16f + explosionRadius);

                // Ensure that all tile coordinates are within the world bounds
                Utils.ClampWithinWorld(ref minTileX, ref minTileY, ref maxTileX, ref maxTileY);

                // These 2 methods handle actually mining the tiles and walls while honoring tile explosion conditions
                bool explodeWalls = projectile.ShouldWallExplode(projectile.Center, explosionRadius, minTileX, maxTileX, minTileY, maxTileY);
                projectile.ExplodeTiles(projectile.Center, explosionRadius, minTileX, maxTileX, minTileY, maxTileY, explodeWalls);
                foreach (Player player in Main.player)
                {
                    if ((damageAll || player == Main.player[Main.myPlayer]) && player.Distance(projectile.Center) / 16 <= explosionRadius && damage>0)
                    {
                        Random random = new();
                        string message = deathMessages[random.Next(deathMessages.Length)];
                        player.Hurt(PlayerDeathReason.ByCustomReason(player.name + message), damage, 1);
                    }
                }

                foreach (NPC npc in Main.npc) { 
                    if(npc.Distance(projectile.Center)/16 <= explosionRadius)
                    {
                        //npc.StrikeNPC(npc.CalculateHitInfo(damage, 1, false, 0));
                        NetMessage.SendStrikeNPC(npc, npc.CalculateHitInfo(damage, 1, false, 0));
                    }
                }
            }
        }
    }
}
