using Microsoft.Xna.Framework;
using RS4A.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    internal class PotionOfExploding : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.consumable = true;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.rare = ItemRarityID.Green;
            Item.sellPrice(silver: 67);
            Item.UseSound = SoundID.Item3;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI != Main.myPlayer)
            {
                return null;
            }
            Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.PotionOfExplodingProjectile>(), 100, 1);
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Dynamite, 1);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.Register();
        }

    }
}
