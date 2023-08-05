using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class LG : ModItem
    {
        public override void SetStaticDefaults()
        {
            //
            //DisplayName.SetDefault("TRANS sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            //Tooltip.SetDefault("C:");
        }

        public override void SetDefaults()
        {
            Item.damage = 700;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.scale = 1f;
            Item.width = 50;
            Item.height = 50;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 100000;
            Item.rare = ItemRarityID.Pink;
            Item.crit = 50;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

        }
        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) //tf
        {
            target.Male = !target.Male; //uh oh
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LivingRainbowDye, 5);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
