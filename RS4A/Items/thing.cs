using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class thing : ModItem
    {
        public override void SetDefaults()
        {
            
            item.CloneDefaults(ItemID.AmethystHook);
           
            item.shootSpeed = 18f; // how quickly the hook is shot.
            item.shoot = mod.ProjectileType("D");
        }
        public override void AddRecipes()  //How to craft this item
        {
         
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PinkSlime, 10);   //you need 10 Wood
            recipe.AddTile(TileID.Anvils);   //craftable at any anvils
            recipe.SetResult(this);
            recipe.AddRecipe();
            
        }
    }
}