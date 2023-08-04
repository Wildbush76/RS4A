using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RS4A.Tiles;
namespace RS4A.Projectiles
{
	public class Gayp : ModProjectile
	{
		public override void SetStaticDefaults()
		{

			DisplayName.SetDefault("Gay juice");

		}
		public override void SetDefaults()
		{
			projectile.damage = 100;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.width = 15;
			projectile.height = 15;
			projectile.aiStyle = 0;
			projectile.penetrate = 5;
			projectile.magic = true;


		}
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
			target.AddBuff(mod.BuffType("Gay"), 36000);
		}
    }
}
