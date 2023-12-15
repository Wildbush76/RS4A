using RS4A.PlayerStuff;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class HydrogenBomb : ModItem
    {
        public override void SetDefaults()
        {
            Item.shoot = ModContent.ProjectileType<Projectiles.HydrogenBombProjectile>();
            Item.width = 32;
            Item.height = 32;
            Item.consumable = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.maxStack = 5;
            Item.autoReuse = false;
            Item.scale = 1f;
            Item.shootSpeed = 2f;
            Item.accessory = true; //the fact it can be both is really fucking funny
            Item.rare = ItemRarityID.Lime;

        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ModContent.ItemType<Items.NuclearFuelRod>(), 3);
            recipe.AddIngredient(ItemID.Wire, 200);
            recipe.AddIngredient(ItemID.Explosives, 5);
            recipe.AddIngredient(ItemID.IronBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }


    }

}
