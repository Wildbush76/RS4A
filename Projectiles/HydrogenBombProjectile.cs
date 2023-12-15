using Microsoft.Xna.Framework;
using RS4A.Tiles;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Projectiles
{
    public class HydrogenBombProjectile : ModProjectile
    {
        private const int blastRadius = 160;//includes the burnt block radius
        private const int burntBlockLayers = 30;
        private const float playerDamageRadius = 180 * 8;
        private const int maxDamge = 9999999; //KILL
        private readonly int[] craterTiles = {ModContent.TileType<RadioactiveStone>()};
        public override void SetDefaults()
        {
            Projectile.damage = 500;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 32;
            Projectile.height = 16;
            Projectile.aiStyle = 16;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 180;
        }
        public override void OnKill(int timeLeft)//TODO update this to be not bad
        {

            bool f = false;
            Vector2 position = Projectile.Center;
            SoundEngine.PlaySound(SoundID.Item14, position);
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
                                WorldGen.PlaceTile(xPosition, yPosition, craterTiles[random.Next(0, craterTiles.Length)], true);
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
                                deathMessage = " didn't get away in time";
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
