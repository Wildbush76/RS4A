using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace RS4A.Items
{
    class Geiger_counter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Geiger counter");
            Tooltip.SetDefault("Displays radation levels");

        }
        public override void SetDefaults()
        {
            item.accessory = true;
            item.value = 10000;
            item.rare = ItemRarityID.Red;
            
        }
        
      
    }
}
