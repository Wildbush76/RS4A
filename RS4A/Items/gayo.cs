using Terraria.ID;
using Terraria.ModLoader;
using RS4A.Buffs;

namespace RS4A.Items
{
	public class Gayo : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Gay-Inator Mk1");
			Tooltip.SetDefault("Become the gay");
		}

		public override void SetDefaults() 
		{
			item.shootSpeed = 10f;
			item.shoot = mod.ProjectileType("Gayp");  //add gayp here
			item.damage = 200;
			item.magic = true;
			item.mana = 20;
			item.scale = 1.25f;
			item.width = 50;
			item.height = 50;
			item.useTime = 2;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Expert;
			item.crit = 100;
			item.autoReuse = false;
	
		}

		public override void AddRecipes() 
		{
                    
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LivingRainbowDye,5);
			recipe.AddIngredient(mod.ItemType("Uranium_bar"),5);
			recipe.AddIngredient(ItemID.RainbowRod,1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
      
		}
		
	}
}
