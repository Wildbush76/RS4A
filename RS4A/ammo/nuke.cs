using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class Nuke : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nuke");
            Tooltip.SetDefault("shootable nuke");
        }
        public override void SetDefaults()
        {
            item.maxStack = 999; 
        }
      
       
       public override void AddRecipes()
	   {
	ModRecipe recipe = new ModRecipe(mod);
	recipe.AddIngredient(null,"Uranium_bar",10);
	recipe.AddIngredient(ItemId.MiniNuke2,10);
	recipe.AddIngredient(ItemId.Wire,10);
	recipe.AddTile(TileID.MythrilAnvil);
	recipe.SetResult(this,10);
	recipe.AddRecipe();
       }
    
    }
}
