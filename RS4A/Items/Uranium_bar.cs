using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class Uranium_bar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Uranium Bar");
            Tooltip.SetDefault("Tastes good");
        }
        public override void SetDefaults()
        {
            item.maxStack = 99; 
        }
      
       
       public override void AddRecipes()
	   {
	ModRecipe recipe = new ModRecipe(mod);
	recipe.AddIngredient(null,"Uranium_or",3);
	recipe.AddTile(TileID.AdamantiteForge);
	recipe.SetResult(this,1);
	recipe.AddRecipe();
       }
    
    }
}
