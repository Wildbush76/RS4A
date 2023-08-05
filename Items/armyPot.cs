
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class armyPot : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Army Potion");
            // Tooltip.SetDefault("Makes you an army recruiter.");
        }

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
            Item.value = Item.buyPrice(platinum: 2);
            Item.buffType = ModContent.BuffType<Buffs.army>(); //Specify an existing buff to be applied when used.
            Item.buffTime = 36000; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Fireblossom, 10);
            recipe.AddIngredient(ItemID.Shiverthorn, 10);
            recipe.AddIngredient(ItemID.Waterleaf, 10);
            recipe.AddIngredient(ItemID.Deathweed, 10);

            recipe.AddIngredient(ItemID.PygmyNecklace, 1);
            recipe.AddIngredient(ItemID.SummonerEmblem, 1);

            recipe.AddIngredient(ItemID.BottledHoney, 1);

            recipe.AddTile(TileID.AlchemyTable);
            recipe.Register();
        }
    }
}
