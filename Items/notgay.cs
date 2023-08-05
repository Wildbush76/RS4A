using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using RS4A.Buffs;
namespace RS4A.Items
{
    class Hazmat : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Not-Gay License");
            //Tooltip.SetDefault("Makes you immune to gay");

        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = 0;
            Item.rare = ItemRarityID.White;

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[ModContent.BuffType<Gay>()] = true;
        }
        public override void AddRecipes()
        {

            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HolyWater, 10);
            recipe.AddIngredient(ItemID.LeadBar, 10);
            recipe.AddIngredient(ItemID.PurificationPowder, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

        }
    }
}
