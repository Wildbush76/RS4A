using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RS4A.Tiles;
using RS4A.Items;
namespace RS4A.Projectiles
{
	public class Throwing_nurse : ModProjectile
	{
		public override void SetStaticDefaults()
		{

			// DisplayName.SetDefault("Throwing nurses");

		}
		public override void SetDefaults()
		{
			Projectile.scale = 0.5f;
			Projectile.damage = 40;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.width = 15;
			Projectile.height = 15;
			Projectile.aiStyle = 1;
			Projectile.penetrate = 3;
		}

        public override void Kill(int timeLeft)
        {
			Vector2 position = Projectile.Center;
			Dust.NewDust(position, 22, 22, DustID.Blood, 0.0f, 0.0f, 120, new Color(), 1f);
		}
    }
}
