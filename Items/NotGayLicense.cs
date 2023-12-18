using RS4A.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Items
{
    class NotGayLicense : ModItem
    {
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
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            return !player.HasBuff(ModContent.BuffType<Buffs.Gay>());
            
        }
    }
}
