using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RS4A.Items
{
   public class Hbomb : ModItem
  {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Hydrogen Bomb");
			Tooltip.SetDefault("its a very large bomb");
		}
        public override void SetDefaults()
		{
				
			item.width = 32;
			item.height = 32;
			item.consumable = true;
			item.useStyle = 1;
			item.useTime = 20;
			item.useAnimation = 20;
			item.createTile = mod.TileType("H_Bomb");
			item.maxStack = 1;
			item.autoReuse = false;
		}
		public override void AddRecipes()
	   {
	ModRecipe recipe = new ModRecipe(mod);
	recipe.AddIngredient(null,"Fuel_cell",3);
	recipe.AddIngredient(ItemID.Wire,200);
	recipe.AddIngredient(ItemID.Exsposive,5);
	recipe.AddIngredient(ItemID.IronBar,20);
	recipe.AddTile(TileID.MythrilAnvil);
	recipe.SetResult(this,1);
	recipe.AddRecipe();
       }
       public override void AddRecipes()
	   {
	ModRecipe recipe = new ModRecipe(mod);
	recipe.AddIngredient(null,"Fuel_cell",3);
	recipe.AddIngredient(ItemID.Wire,200);
	recipe.AddIngredient(ItemID.Exsposive,5);
	recipe.AddIngredient(ItemID.LeadBar,20);
	recipe.AddTile(TileID.MythrilAnvil);
	recipe.SetResult(this,1);
	recipe.AddRecipe();
       }
         
   }

}
