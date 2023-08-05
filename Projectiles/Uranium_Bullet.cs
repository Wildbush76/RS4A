using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Projectiles
{
	public class UrBullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{

			// DisplayName.SetDefault("Uranium Bullet");

		}
		public override void SetDefaults()
		{
			Projectile.damage = 10;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.aiStyle = 0;
			Projectile.penetrate = 2;

		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(Mod.Find<ModBuff>("Rad").Type, 120);
        }




    }
}
