using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;

namespace RS4A.RS4AUtils
{
    internal class Explode
    {

        public static void Explosion(Projectile projectile, int explosionRadius, int damage, bool damageAll, string[] deathMessages) {
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
                foreach(Player player in Main.player)
                {
                    if ((damageAll || player == Main.player[Main.myPlayer]) && player.Distance(projectile.Center)/16 <= explosionRadius) {
                        Random random = new();
                        string message = deathMessages[random.Next(deathMessages.Length)];
                        player.Hurt(PlayerDeathReason.ByCustomReason(player.name + message), damage, 1);
                    }
                }
            }
        }
    }
}
