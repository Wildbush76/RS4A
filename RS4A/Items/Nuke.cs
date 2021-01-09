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
            DisplayName.SetDefault("Nuke");
            Tooltip.SetDefault("shootable nuke");
        }
        public override void SetDefaults()
        {
           item.damage = 10;
			item.ranged = true;
			item.width = 7;
			item.height = 13;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 1.2f;
			item.rare = ItemRarityID.Blue;
			item.shoot = mod.ProjectileType("Nukep");
			item.shootSpeed = 8.5f;
			item.ammo = AmmoID.Rocket;
        }
      
       public override void AddRecipes()
	   {
	ModRecipe recipe = new ModRecipe(mod);
	recipe.AddIngredient(null,"Uranium_bar",10);
	recipe.AddIngredient(ItemID.RocketIV,10);
	recipe.AddIngredient(ItemID.Wire,10);
	recipe.AddTile(TileID.MythrilAnvil);
	recipe.SetResult(this,10);
	recipe.AddRecipe();
       }
    
    }
}
