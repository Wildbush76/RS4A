using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
	public class Glowstickgernade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Glowstick gernade");		
		}
		public override void SetDefaults() 
		{
			item.damage = 0;
			item.ranged = true;
                        item.consumable = true;
			item.shoot = mod.ProjectileType("GlowG");
			item.width = 5;
			item.height = 5;
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 100;
			item.rare = 5;
			item.crit = 45;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gernade, 10);
			recipe.AddIngredient(ItemID.GlowStick, 6);
			recipe.AddTile(TileID.CraftingBench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
