using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class Nuke : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 100;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 7;
            Item.height = 13;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.knockBack = 1.2f;
            Item.rare = ItemRarityID.Blue;
            Item.shoot = ModContent.ProjectileType<Projectiles.NukeProjectile>()-134;
            Item.value = 1;
            Item.shootSpeed = 15;
            Item.ammo = AmmoID.Rocket;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(10);
            recipe.AddIngredient(ModContent.ItemType<Items.NuclearFuelRod>(), 1);
            recipe.AddIngredient(ItemID.RocketIV, 10);
            recipe.AddIngredient(ItemID.Wire, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

    }
}
