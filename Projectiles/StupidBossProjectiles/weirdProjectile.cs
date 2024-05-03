using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace RS4A.Projectiles.StupidBossProjectiles
{
    public class WeirdProjectile : ModProjectile
    {
        public bool FadedIn
        {
            get => Projectile.localAI[0] == 1f;
            set => Projectile.localAI[0] = value ? 1f : 0f;
        }

        public bool PlayedSpawnSound
        {
            get => Projectile.localAI[1] == 1f;
            set => Projectile.localAI[1] = value ? 1f : 0f;
        }

        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.alpha = 0;
            Projectile.scale = 2f;
            Projectile.timeLeft = 300;
            Projectile.penetrate = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.netImportant = true;
            Projectile.aiStyle = -1;
            CooldownSlot = ImmunityCooldownID.Bosses; // use the boss immunity cooldown counter, to prevent ignoring boss attacks by taking damage from other sources
        }

        public override Color? GetAlpha(Color lightColor)
        {
            // When overriding GetAlpha, you usually want to take the projectiles alpha into account. As it is a value between 0 and 255,
            // it's annoying to convert it into a float to multiply. Luckily the Opacity property handles that for us (0f transparent, 1f opaque)
            return Color.White * Projectile.Opacity;
        }

        private void FadeInAndOut()
        {
            // Fade in (we have Projectile.alpha = 255 in SetDefaults which means it spawns transparent)
            int fadeSpeed = 10;
            if (!FadedIn && Projectile.alpha > 0)
            {
                Projectile.alpha -= fadeSpeed;
                if (Projectile.alpha < 0)
                {
                    FadedIn = true;
                    Projectile.alpha = 0;
                }
            }
            else if (FadedIn && Projectile.timeLeft < 255f / fadeSpeed)
            {
                // Fade out so it aligns with the projectile despawning
                Projectile.alpha += fadeSpeed;
                if (Projectile.alpha > 255)
                {
                    Projectile.alpha = 255;
                }
            }
        }
        private Player player;
        private int ticksPassed = 0;
        private Vector2 initalVelocity;

        public override void AI()
        {
            ticksPassed++;

            if (!PlayedSpawnSound)
            {
                PlayedSpawnSound = true;

                // Common practice regarding spawn sounds for projectiles is to put them into AI, playing sounds in the same place where they are spawned
                // is not multiplayer compatible (either no one will hear it, or only you and not others)
                SoundEngine.PlaySound(SoundID.Item8, Projectile.position);
            }

            // Accelerate
            if (ticksPassed < 50)
            {
                Stage1();
            } else if (ticksPassed == 50)
            {
                IntermediateStage();

            } else if (ticksPassed<80)
            {
                Stage2();
            }

            // If the sprite points upwards, this will make it point towards the move direction (for other sprite orientations, change MathHelper.PiOver2)
            Projectile.rotation += 0.1f;
        }
        private void Stage1()
        {
            Projectile.velocity = Vector2.Lerp(Projectile.velocity, Vector2.Zero, (float)ticksPassed / 80f);
        }
        private void IntermediateStage()
        {
            double closest = 1300;
            Player closestPlayer = null;

            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player player = Main.player[i];
                if (player.active && !player.dead)
                {
                    double dist = Vector2.Distance(Projectile.Center, player.Center);
                    if (dist < closest)
                    {
                        closest = dist;
                        closestPlayer = player;
                    }
                }
            }
            Vector2 positionToGoTo = Vector2.Zero;
            if (closestPlayer != null)
            {
                Vector2 offset = Vector2.Zero;
                if (Main.rand.Next(0,2)==0)
                {
                    offset = closestPlayer.velocity * 50f;
                }
                positionToGoTo = closestPlayer.Center + new Vector2(Main.rand.NextFloat(-70f, 70f), Main.rand.NextFloat(-70f, 70f)) + offset;

            }
            Vector2 fromPosition = positionToGoTo - Projectile.Center;
            float angle = fromPosition.ToRotation();
            Projectile.velocity = angle.ToRotationVector2()*3f;
            initalVelocity = Projectile.velocity;
        }
        private void Stage2()
        {
            Projectile.velocity *= 1.07f;
        }
    }
}