using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class Nuke : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Nuke");
            //Tooltip.SetDefault("This is a great idea!");
        }
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 7;
            Item.height = 13;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.knockBack = 1.2f;
            Item.rare = ItemRarityID.Blue;
            Item.shoot = Mod.Find<ModProjectile>("Nukep").Type;
            Item.shootSpeed = 8.5f;
            Item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(10);
            recipe.AddIngredient(null, "Uranium_bar", 10);
            recipe.AddIngredient(ItemID.RocketIV, 10);
            recipe.AddIngredient(ItemID.Wire, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

    }
}
