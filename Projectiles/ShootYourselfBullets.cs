using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    internal class ShootYourselfBullets : ModProjectile
    {
        public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.Bullet;
        public override void SetStaticDefaults()
        {
            Projectile.aiStyle = 52;
            Projectile.damage = 5;
            Projectile.friendly = false;
            Projectile.hostile = true;

        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
           //do nothing ig
        }
    }
}
