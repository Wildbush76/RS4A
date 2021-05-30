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

			DisplayName.SetDefault("Throwing nurses");

		}
		public override void SetDefaults()
		{
			projectile.scale = 0.5f;
			projectile.damage = 40;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.width = 15;
			projectile.height = 15;
			projectile.aiStyle = 1;
			projectile.penetrate = 3;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			Random a = new Random();
			int asd = a.Next(1, 6);
			if (asd == 5)
			{
				Item.NewItem(projectile.getRect(), ItemID.Heart);
			}
		}
        public override void Kill(int timeLeft)
        {
			Vector2 position = projectile.Center;
			Dust.NewDust(position, 22, 22, DustID.Blood, 0.0f, 0.0f, 120, new Color(), 1f);
			Random a = new Random();
			int asd = a.Next(1, 6);
			if (asd == 5)
			{
				Item.NewItem(projectile.getRect(), ModContent.ItemType<Tnurse>());
			}
		}
    }
}
