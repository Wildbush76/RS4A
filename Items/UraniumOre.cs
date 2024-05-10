using RS4A.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class UraniumOre : ModItem
    {

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 75;
        }
        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 8;
            Item.consumable = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.createTile = ModContent.TileType<Tiles.UraniumOre>();
            Item.maxStack = Item.CommonMaxStack;
            Item.autoReuse = true;
            Item.value = 6666;
        }
        public override void UpdateInventory(Player player)
        {
            player.AddBuff(ModContent.BuffType<Radiation3>(), 10);
        }
        public override void HoldItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Radiation3>(), 10);
        }



    }


}
