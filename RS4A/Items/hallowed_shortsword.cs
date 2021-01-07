using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
	public class hallowed_shortsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Hallowed Shortsword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The real deal.");
		}

		public override void SetDefaults() 
		{
			item.damage = 67;
			item.melee = true;
			item.scale = 1.25f;
			item.width = 50;
			item.height = 50;
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = 3;
			item.knockBack = 6;
			item.value = 100000;
			item.rare = 5;
			item.crit = 45;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(ItemID.CopperShortsword, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
