using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    public class dyno_arrow : ModProjectile
    {
        public override void SetStaticDefaults()
			{

				DisplayName.SetDefault("Dynamite arrows");

			}
			public override void SetDefaults()
			{
				projectile.damage = 30;
				projectile.friendly = true;
				projectile.ranged = true;
				projectile.width = 14;
				projectile.height = 32;
				projectile.aiStyle = 1;
				projectile.penetrate = 1;
				projectile.arrow = true;

			}
			public override void kill()
			{
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, ProjectileID.StickyDynamite, 100, 0, projectile.whoAmI);
			}


        
    }
}
