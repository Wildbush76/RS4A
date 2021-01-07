using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class Nfuel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nuclear fuel cell");
            Tooltip.SetDefault("Its a oversized glow stick");
        }
        public override void SetDefaults()
        {
            item.maxStack = 99; 
        }
      
       
       public override void AddRecipes()
	   {
	ModRecipe recipe = new ModRecipe(mod);
	recipe.AddIngredient(null,"Uranium_bar",3);
	recipe.AddIngredient(ItemId.LeadBars,3);
	recipe.AddIngredient(ItemId.Wire,10);
	recipe.AddTile(TileID.MythrilAnvil);
	recipe.SetResult(this,1);
	recipe.AddRecipe();
       }
    
    }
}
