using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class UraniumBar : ModItem
    {
        public override void SetDefaults()
        {
            Item.maxStack = 99;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ModContent.ItemType<Items.UraniumOre>(), 3);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();
        }

    }
}
