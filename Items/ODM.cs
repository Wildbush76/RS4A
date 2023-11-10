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
            // DisplayName.SetDefault("ODM gear");
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.AmethystHook);
          
            Item.shootSpeed = 40f;
            Item.shoot = Mod.Find<ModProjectile>("ODM").Type;
        }
        public override void AddRecipes() 
        {
          
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 10); 
            recipe.AddTile(TileID.Anvils); 
            recipe.Register();
            
        }
    }
}