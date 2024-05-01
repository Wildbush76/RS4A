using RS4A.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class UraniumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;

        }
        public override void UpdateInventory(Player player)
        {
            player.AddBuff(ModContent.BuffType<Radiation3>(), 10);
        }
        public override void HoldItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Radiation3>(), 10);
        }
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.UraniumBar>());
            Item.width = 20;
            Item.height = 20;
            Item.value = 670;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ModContent.ItemType<UraniumOre>(), 3);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();
        }

    }
}
