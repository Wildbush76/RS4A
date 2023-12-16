using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    public class FirstPrismSpray : ModProjectile
    {
        //public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.RainbowRodBullet;
        private const float Gravity = 0.5f;
        private const float XVelocityDamping = 0.99f;

        public override void SetDefaults()
        {
            Projectile.damage = 5;
            Projectile.friendly = true;
            Projectile.width = 15;
            Projectile.height = 15;
            Projectile.penetrate = 3;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.light = 0.4f;
        }
        public override void AI()
        {
            Projectile.velocity.Y += Gravity;
            Projectile.velocity.X *= XVelocityDamping;
            Vector2 vel = Vector2.Normalize(Projectile.velocity) * -0.5f;
            Dust.NewDust(Projectile.Center, Projectile.width / 2, Projectile.height / 2, DustID.PurificationPowder, vel.X, vel.Y);
        }
    }
}
