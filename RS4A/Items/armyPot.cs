
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace death.Items
{
    public class armyPot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Army Potion");
            Tooltip.SetDefault("Makes you an army recruiter.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Expert;
            item.value = Item.buyPrice(platinum: 2);
            item.buffType = ModContent.BuffType<Buffs.army>(); //Specify an existing buff to be applied when used.
            item.buffTime = 36000; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Fireblossom, 999);
            recipe.AddIngredient(ItemID.Shiverthorn, 999);
            recipe.AddIngredient(ItemID.Waterleaf, 999);
            recipe.AddIngredient(ItemID.Deathweed, 999);

            recipe.AddIngredient(ItemID.PapyrusScarab, 1);
            recipe.AddIngredient(ItemID.HerculesBeetle, 1);
            recipe.AddIngredient(ItemID.PygmyNecklace, 1);
            recipe.AddIngredient(ItemID.NecromanticScroll, 1);
            recipe.AddIngredient(ItemID.PygmyStaff, 1);
            recipe.AddIngredient(ItemID.SummonerEmblem, 1);
            recipe.AddIngredient(ItemID.StardustCellStaff, 1);
            recipe.AddIngredient(ItemID.StardustDragonStaff, 1);
            recipe.AddIngredient(ItemID.RainbowCrystalStaff, 1);

            recipe.AddIngredient(ItemID.BottledHoney, 1);

            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}