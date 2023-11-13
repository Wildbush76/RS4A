using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    internal class OrbitalStrikeProjectile : ModProjectile
    {
        private const int blastRadius = 20;//includes the burnt block radius
        private const int burntBlockLayers = 6;
        private const float playerDamageRadius = 100 * 8;
        private const int maxDamge = 20000;
        private ushort[] craterTiles = {TileID.Obsidian,TileID.Ash,TileID.Meteorite};
        public override void SetDefaults()
        {
            Projectile.damage = 1;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 42;
            Projectile.height = 95;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 1;
        }
        public override void OnKill(int timeleft)
        {

            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ProjectileID.DD2ExplosiveTrapT3Explosion, 0, 0);
            Random random = new();
            for (int x = -blastRadius; x <= blastRadius; x++)
            {
                for (int y = -blastRadius; y <= blastRadius; y++)
                {
                    int xPosition = (int)(x + Projectile.Center.X / 16.0f);
                    int yPosition = (int)(y + Projectile.Center.Y / 16.0f);
                    double dist = Math.Sqrt(x * x + y * y);
                    if (dist <= blastRadius && Framing.GetTileSafely(xPosition, yPosition).HasTile)
                    {

                        if (dist > blastRadius - burntBlockLayers)
                        {

                            int replaceChance = (int)((dist - (blastRadius - burntBlockLayers)) / 2) + 1;
                            if (random.Next(0, replaceChance) == 0)
                            {
                                WorldGen.KillTile(xPosition, yPosition, false, false, true);
                                WorldGen.KillWall(xPosition, yPosition);
                                WorldGen.PlaceTile(xPosition, yPosition, craterTiles[random.Next(0,craterTiles.Length)], true);
                            }
                        }
                        else
                        {
                            WorldGen.KillTile(xPosition, yPosition, false, false, true);
                            WorldGen.KillWall(xPosition, yPosition);
                        }
                        Dust.NewDust(new Vector2(xPosition, yPosition), 22, 22, DustID.FlameBurst, 0.0f, 0.0f, 120, new Color(), 1f);
                    }
                }

            }
            for (int player = 0; player < Main.maxPlayers; player++)
            {
                Player targetPlayer = Main.player[player];
                if (targetPlayer.active && !targetPlayer.dead)
                {
                    float dist = Vector2.Distance(Projectile.Center, targetPlayer.Center);
                    if (dist < playerDamageRadius)
                    {
                        int damage = (int)((playerDamageRadius - dist) / playerDamageRadius * maxDamge);
                        String deathMessage = "";
                        switch (random.Next(0, 4))
                        {
                            case 0:
                                deathMessage = " was reduced to sub-atomic particles";
                                break;
                            case 1:
                                deathMessage = " was turned into radiactive ash";
                                break;
                            case 2:
                                deathMessage = " was obliterated";
                                break;
                            case 3:
                                deathMessage = " was annilaited by " + Main.player[Projectile.owner].name;
                                break;
                        }
                        //apply calulated damage to the target player here

                        targetPlayer.Hurt(PlayerDeathReason.ByCustomReason(targetPlayer.name + deathMessage), damage, 1, dodgeable: false);
                    }
                }
            }
        }
    }
}
