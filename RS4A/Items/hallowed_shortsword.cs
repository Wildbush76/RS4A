using Terraria.ID;
using Terraria.ModLoader;

namespace death.Items
{
	public class dead : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cool Shortie"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("your mother is ashamed");
		}

		public override void SetDefaults() 
		{
			item.damage = 75;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 1;
			item.useAnimation = 1;
			item.useStyle = 3;
			item.knockBack = 3;
			item.value = 10000;
			item.rare = 6;
			item.crit = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
