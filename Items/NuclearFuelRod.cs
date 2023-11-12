using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class NuclearFuelRod : ModItem
    {
        public override void SetDefaults()
        {
            Item.maxStack = 99;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ModContent.ItemType<Items.UraniumBar>(), 3);
            recipe.AddIngredient(ItemID.LeadBar, 3);
            recipe.AddIngredient(ItemID.Wire, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }


    }
}
