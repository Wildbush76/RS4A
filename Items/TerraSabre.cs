using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Items

{
    public class TerraSabre : ModItem
    {

        public override void SetDefaults()
        {
            DateTime today = DateTime.Today;
            if (today.Day == 2 && today.Month == 6)
            {
                Item.damage = 200;
                Item.rare = ItemRarityID.Lime;
                Item.autoReuse = true;
                Item.crit = 41;
                Item.value = 100000;
                Item.useTime = 8;
                Item.useAnimation = 8;
            }
            else
            {
                Item.damage = 10;
                Item.rare = ItemRarityID.Gray;
                Item.autoReuse = false;
                Item.crit = 1;
                Item.value = 1;
                Item.useTime = 30;
                Item.useAnimation = 30;
            }
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 46;
            Item.height = 54;
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.knockBack = 2;
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GreenPhaseblade, 1);
            recipe.AddIngredient(ItemID.FallenStar, 15);
            recipe.AddIngredient(ItemID.CopperShortsword, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
