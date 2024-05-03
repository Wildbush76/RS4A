using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using RS4A.Tiles;
using Terraria.DataStructures;
using RS4A.Buffs;

namespace RS4A.Projectiles.StupidBossProjectiles
{
    public class ExplosiveWaste : ModProjectile
    {
        private const int blastRadius = 10;//includes the burnt block radius
        private const float playerDamageRadius = 10 * 8;
        private const int maxDamge = 150; //KILL
        private readonly int[] craterTiles = { ModContent.TileType<RadioactiveStone>() };

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.alpha = 0;
            Projectile.timeLeft = 100;
            Projectile.penetrate = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.netImportant = true;
            Projectile.aiStyle = 2;
            CooldownSlot = ImmunityCooldownID.Bosses; // use the boss immunity cooldown counter, to prevent ignoring boss attacks by taking damage from other sources
        }

        public override Color? GetAlpha(Color lightColor)
        {
            // When overriding GetAlpha, you usually want to take the projectiles alpha into account. As it is a value between 0 and 255,
            // it's annoying to convert it into a float to multiply. Luckily the Opacity property handles that for us (0f transparent, 1f opaque)
            return Color.White * Projectile.Opacity;
        }
        public override void OnKill(int timeLeft) //thank ye henry
        {
            Main.NewText("kabew");

            
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
                    Tile currentTile = Framing.GetTileSafely(xPosition, yPosition);
                    if (dist > blastRadius)
                    {


                        int replaceChance = (int)((dist - (blastRadius)) / 2) + 1;
                        if (random.Next(0, replaceChance) == 0)
                        {
                            if (currentTile.HasTile)
                            {
                                //WorldGen.ReplaceTile(xPosition, yPosition, craterTiles[random.Next(0, craterTil)
                                WorldGen.KillTile(xPosition, yPosition, false, false, true);
                                WorldGen.PlaceTile(xPosition, yPosition, craterTiles[random.Next(0, craterTiles.Length)], true);
                            }
                        }
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
                        String deathMessage = "";
                        switch (random.Next(0, 4))
                        {
                            case 0:
                                deathMessage = " was reduced to sub-atomic particles";
                                break;
                            case 1:
                                deathMessage = " was turned into radioactive ash";
                                break;
                            case 2:
                                deathMessage = " was obliterated";
                                break;
                            case 3:
                                deathMessage = " didn't get away in time";
                                break;
                        }
                        //apply calulated damage to the target player here
                        targetPlayer.AddBuff(ModContent.BuffType<Radiation>(),300);
                        targetPlayer.Hurt(PlayerDeathReason.ByCustomReason(targetPlayer.name + deathMessage), 100, 1, dodgeable: true);
                    }
                }
            }
            
        }
    }
}