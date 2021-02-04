using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
	public class gayo : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Gay-Inator Mk1"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The real deal.");
		}

		public override void SetDefaults() 
		{
		
		        //item.shoot =  //add gayp here
			item.damage = 100;
			item.magic = true;
			//item.scale = 1.25f;
			item.width = 50;
			item.height = 50;
			item.useTime = 30;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.Stabbing;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Rainbow;
			item.crit = 100;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			
		}

		public override void AddRecipes() 
		{
                    /*
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(ItemID.CopperShortsword, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
      */
		}
		
	}
}
