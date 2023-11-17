using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class RadiactiveStone : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 8;
            Item.height = 8;
            Item.consumable = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.createTile = ModContent.TileType<Tiles.RadioactiveStone>();
            Item.maxStack = 9999;
            Item.autoReuse = true;
        }

    }

}
