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
            DisplayName.SetDefault("Not gay license");
            Tooltip.SetDefault("makes you immune to gay");

        }
        public override void SetDefaults()
        {
            item.accessory = true;
            item.value = 0;
            item.rare = ItemRarityID.White;
            
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[ModContent.BuffType<Gay>()] = true;
        }
        public override void AddRecipes()
        {
        
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HolyWater,10);
            recipe.AddIngredient(ItemID.LeadBar, 10);
            recipe.AddIngredient(ItemID.PurificationPowder,10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
            
        }
    }
}
