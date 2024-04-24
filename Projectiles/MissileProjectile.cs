using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    internal class MissileProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.damage = 300;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 23;
            Projectile.height = 36;
            Projectile.aiStyle = 34;
            Projectile.penetrate = 1;

        }

    }
}
