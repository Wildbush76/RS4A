using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class ODM : ModItem
    {
        public override void SetDefaults()
        {
            //clone and modify the ones we want to copy
            item.CloneDefaults(ItemID.AmethystHook);
           // item.displayName = "ODM gear";
            item.shootSpeed = 18f; // how quickly the hook is shot.
            item.shoot = mod.ProjectileType("ODM");
        }
        public override void AddRecipes()  //How to craft this item
        {
         /*   
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 10);   //you need 10 Wood
            recipe.AddTile(TileID.Anvils);   //craftable at any anvils
            recipe.SetResult(this);
            recipe.AddRecipe();
            */
        }
    }
}
