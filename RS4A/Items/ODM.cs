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
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ODM gear");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.AmethystHook);
          
            item.shootSpeed = 40f;
            item.shoot = mod.ProjectileType("ODM");
        }
        public override void AddRecipes() 
        {
          
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 10); 
            recipe.AddTile(TileID.Anvils); 
            recipe.SetResult(this);
            recipe.AddRecipe();
            
        }
    }
}
