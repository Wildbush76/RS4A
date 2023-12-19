using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    public class ShootYourselfBullets : ModProjectile
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.ChlorophyteBullet;
        private int trackingDelay = 60;
        private float speed = 0f;
        private const float acceration = 0.1f;
        private const float maxSpeed = 30f;


        public override void SetDefaults()
        {
            Projectile.damage = 2;
            Projectile.hostile = false;
            Projectile.knockBack = 2;
            Projectile.penetrate = 1;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Projectile.timeLeft = 0;
        }
        public override bool CanHitPlayer(Player target)
        {
            return target.whoAmI == Projectile.owner;
        }

       
        public override void AI()
        {
            if (trackingDelay != 0)
            {
                trackingDelay--;
                Projectile.velocity *= 0.9f;
                speed = Projectile.velocity.Length();
                return;
            }
            Projectile.hostile = true;
            Player targetPlayer = Main.player[Projectile.owner];
            Vector2 target = Vector2.Normalize(targetPlayer.Center - Projectile.Center);

            //trackingStrength += trackingModifer;
            //trackingStrength = Math.Clamp(trackingStrength, 0f, 1f);

            speed += acceration;
            speed = Math.Clamp(speed, -maxSpeed, maxSpeed);
            //Projectile.velocity = Vector2.Lerp(Vector2.Normalize(Projectile.velocity), target, trackingStrength) * speed;
            Projectile.velocity = target * speed;

        }

    }
}
