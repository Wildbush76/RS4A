using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items 
{
    internal class RealGravityPotion : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold:10);
            Item.buffType = ModContent.BuffType<Buffs.GravitationReal>(); //Specify an existing buff to be applied when used.
            Item.buffTime = 36000; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }
    }
}
