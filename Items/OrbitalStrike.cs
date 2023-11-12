using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    internal class OrbitalStrike : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.rare = ItemRarityID.Expert;
            Item.consumable = false;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_FromAI(), player.Center + new Vector2(Main.screenWidth, Main.screenHeight), Vector2.Zero, ModContent.ProjectileType<Projectiles.TargetedForOrbitalStrike>(), 0, 0);
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LihzahrdPowerCell, 3);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.MechanicalBatteryPiece, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
