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
            // DisplayName.SetDefault("Uranium Bar");
            // Tooltip.SetDefault("Tastes good");
        }
        public override void SetDefaults()
        {
            Item.maxStack = 99;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(null, "Uranium_or", 3);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();
        }

    }
}
