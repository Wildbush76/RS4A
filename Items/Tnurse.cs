﻿using RS4A.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RS4A.Projectiles;

namespace RS4A.Items
{
	public class Tnurse : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Throwing Nurse");
			// Tooltip.SetDefault("But why????");
		}

		public override void SetDefaults()
		{
			Item.maxStack = 9999;
			Item.shootSpeed = 10f;
			Item.damage = 40;
			Item.scale = 0.5f;
			Item.width = 10;
			Item.height = 10;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 1;
			Item.value = 1000;
			Item.rare = ItemRarityID.Lime;
			Item.crit = 20;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.DamageType = DamageClass.Ranged;
			Item.shoot = ModContent.ProjectileType<Throwing_nurse>();
		}
		/*
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ThrowingKnife,40);
			recipe.AddIngredient(ItemID.LifeCrystal,1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this,40);
			recipe.AddRecipe();
		}
		*/
	}
}
