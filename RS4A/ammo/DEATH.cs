using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
public class DEATH_ammo : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DEATH");
		}
		public override void SetDefaults()
		{
			item.damage = 10000;
			item.ranged = true;
			item.width = 7;
			item.height = 13;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 1.2f;
			item.rare = ItemRarityID.Blue;
			item.shoot = mod.ProjectileType("dyno_arrow");
			item.shootSpeed = 8.5f;
			item.ammo = AmmoID.Arrow;
			

		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow,10000);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this,1);
			recipe.AddRecipe();

		}
	}
