using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RS4A.Tiles;
namespace RS4A.Projectiles
{
	public class Nukep : ModProjectile
	{
		public override void SetStaticDefaults()
		{

			DisplayName.SetDefault("Gay juice");

		}
		public override void SetDefaults()
		{
			projectile.damage = 100;
			projectile.friendly = false;
			projectile.ranged = true;
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 34;
			projectile.penetrate = 1;
			
		}
		public override void Kill(int timeLeft)
		{
		


	}
	}
