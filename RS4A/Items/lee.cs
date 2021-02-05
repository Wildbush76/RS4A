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
            DisplayName.SetDefault("Leroy Jenkins");
            Tooltip.SetDefault("Less defense is good");
        }
        public override void SetDefaults()
        {
            item.accessory = true;
            item.value = 0;
            item.rare = ItemRarityID.Red;
            
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
        var gays = 10;
          if(gays < 100)
          {
          var jj = 100 - gays;
          jj = jj/10;
          }
        }
        public override void AddRecipes()
        {
        /*
            ModRecipe recipe = new ModRecipe(mod);//sounds good
            recipe.AddIngredient(ItemID.Gel, 100);//The wall of flesh mudaleuns and all of the souls(not moded) 
            recipe.AddIngredient(ItemID.LeadBar, 7);
            recipe.AddIngredient(ItemID.HallowedBar,7);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
            */
        }
    }
}
