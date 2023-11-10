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

			// DisplayName.SetDefault("Gay juice");

		}
		public override void SetDefaults()
		{
			Projectile.damage = 100;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.width = 15;
			Projectile.height = 15;
			Projectile.aiStyle = 0;
			Projectile.penetrate = 5;
			Projectile.DamageType = DamageClass.Magic;


		}
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
			target.AddBuff(Mod.Find<ModBuff>("Gay").Type, 36000); //lmao box
		}
    }
}