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
       public override void setStacticDefaults()
       {
        DisplayName.SetDefault("Uranium Bar");
			  Tooltip.SetDefault("Tastes good");
       }
       public override void setDefaults()
       {
       
       }
       public override void AddRecipes()
	{
	ModRecipe recipe = new ModRecipe(mod);
	recipe.AddIngredient(null,"Uranium_ore",3);
	recipe.AddTile(TileID.MythrilAnvil);
	recipe.SetResult(this,1);
	recipe.AddRecipe();
       }
    
    }
}
