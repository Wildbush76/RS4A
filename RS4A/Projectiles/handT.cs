using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Projectiles
{
	public class handT : ModProjectile
	{
		public override void SetStaticDefaults()
		{

			DisplayName.SetDefault("hand");

		}
		public override void SetDefaults()
		{
			projectile.scale = 1;
			projectile.damage = 30;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.width = 30;
			projectile.height = 24;
			projectile.aiStyle = 2;
			projectile.penetrate = 9999;
			projectile.tileCollide = true;
			projectile.velocity *= 1.9f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.defense = 0;
			target.AddBuff(BuffID.Venom, 240);
			Main.PlaySound(2, projectile.position, 14);

		}
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
		}
	}
}
