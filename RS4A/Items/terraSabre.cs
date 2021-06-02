  using Terraria.ID;
using Terraria.ModLoader;
using System;
namespace RS4A.Items

{
	public class terraSabre : ModItem
	{
		public override void SetStaticDefaults() 
		{

			DateTime today = DateTime.Today;
			if (today.Month == 6 && today.Day == 2)
			{
				DisplayName.SetDefault("Terra Sabre");
				Tooltip.SetDefault("Must be your lucky day!");
			} else
            {
				DisplayName.SetDefault("Foam Terra Sabre");
				Tooltip.SetDefault("Straight out of TerraMart!");
			}
		}

		public override void SetDefaults()
		{
			DateTime today = DateTime.Today;
			if (today.Day == 2 && today.Month == 6) 
			{
				item.damage = 200;
				item.rare = ItemRarityID.Lime;
				item.autoReuse = true;
				item.crit = 41;
				item.value = 100000;
				item.useTime = 8;
				item.useAnimation = 8;
			} else
            {
				item.damage = 10;
				item.rare = ItemRarityID.Gray;
				item.autoReuse = false;
				item.crit = 1;
				item.value = 1;
				item.useTime = 30;
				item.useAnimation = 30;
			}
			item.melee = true;
			item.width = 46;
			item.height = 54;
			item.useStyle = ItemUseStyleID.Stabbing;
			item.knockBack = 2;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GreenPhaseblade, 1);
			recipe.AddIngredient(ItemID.FallenStar, 15);
			recipe.AddIngredient(ItemID.CopperShortsword, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
