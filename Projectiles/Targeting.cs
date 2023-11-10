using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    internal class Targeting : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.penetrate = 1;
            Projectile.damage = 1;
            Projectile.friendly = false;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = false;
           
        }


        public override void OnKill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position - new Vector2(0, Main.screenHeight), new Vector2(0, 30), ModContent.ProjectileType<Projectiles.OrbitalStrikeProjectile>(), 200, 1);
        }

        public override void AI()
        {
            Projectile.position = Main.player[Projectile.owner].Center;
            Projectile.rotation += MathHelper.ToRadians(6);
            
           
        }
    }
}
