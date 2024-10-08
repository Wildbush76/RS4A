using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class HallowedShortsword : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 67;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.scale = 1.25f;
            Item.width = 50;
            Item.height = 50;
            Item.useTime = 7;
            Item.useAnimation = 7;
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.knockBack = 6;
            Item.value = 100000;
            Item.rare = ItemRarityID.Pink;
            Item.crit = 45;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddIngredient(ItemID.CopperShortsword, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
