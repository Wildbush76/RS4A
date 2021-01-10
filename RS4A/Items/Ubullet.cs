using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
	public class Ubullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Uranium Bullets");
			
		}
		public override void SetDefaults()
		{
			item.damage = 10;
			item.ranged = true;
			item.width = 7;
			item.height = 13;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 1.2f;
			item.rare = ItemRarityID.Blue;
			item.shoot = mod.ProjectileType("UrBullet");
			item.shootSpeed = 8.5f;
			item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Uranium_bar",1);
			recipe.AddIngredient(ItemID.MusketBall, 50);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}

	}
}
