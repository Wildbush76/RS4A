using System.CodeDom;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;

namespace RS4A.Projectiles
{
    public class ShootYourselfBullets : ModProjectile
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.ChlorophyteBullet;
        private const float timeModifer = 0.3f;
        private float speed = 1;
        private const float maxVelocity = 40;
        private bool tracking = false;



        public override void SetDefaults()
        {
            Projectile.damage = 2;
            Projectile.hostile = true;
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
        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            target.SetImmuneTimeForAllTypes(0);            
        }

        public override void AI()
        {

            if (tracking)
            {
                Player target = Main.player[Projectile.owner];
                if (target is null || target.dead || !target.active) {
                    Projectile.active = false;
                }
            
                speed += timeModifer;
                Math.Clamp(speed, 0, maxVelocity);
                Projectile.velocity = Vector2.Normalize(target.Center - Projectile.Center) * speed;
            }
            else {
                Projectile.velocity *= 0.9f;
                if (Projectile.velocity.Length() < 0.2f) {
                    tracking = true;
                }
            }
        }
       
    }
}
