using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

using Terraria.DataStructures;
using Terraria.GameContent;

namespace RS4A.Projectiles
{
    internal class OrbitalStrikeProjectile : ModProjectile
    {
        private const int blastRadius = 20;//includes the burnt block radius
        private const int burntBlockLayers = 6;
        private const float playerDamageRadius = 100 * 8;
        private const int maxDamge = 20000;
        public override void SetDefaults()
        {
            Projectile.damage = 1;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 1;


        }
        public override void OnKill(int timeleft)
        {
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
                                WorldGen.PlaceTile(xPosition, yPosition, TileID.Obsidian, true);
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
                        int damage = (int)(playerDamageRadius / (playerDamageRadius - dist) * maxDamge);
                        //apply calulated damage to the target player here
                        targetPlayer.Hurt(PlayerDeathReason.ByCustomReason(targetPlayer.name + " was reduced to sub-atomic particles"), damage, 1, dodgeable: false);
                    }
                }
            }
        }
    }
}
