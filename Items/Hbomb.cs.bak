using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RS4A.Items
{
   public class Hbomb : ModItem
  {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Hydrogen Bomb");
			Tooltip.SetDefault("its a very large bomb");
		}
        public override void SetDefaults()
		{
			item.shoot = mod.ProjectileType("H_Bomb");
			item.width = 32;
			item.height = 32;
			item.consumable = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTime = 20;
			item.useAnimation = 20;
			item.consumable = true;
			item.maxStack = 5;
			item.autoReuse = false;
			item.scale = 1f;
			item.shootSpeed = 2f;
		}
		public override void AddRecipes()
	   {
	ModRecipe recipe = new ModRecipe(mod);
	recipe.AddIngredient(null,"Nfuel",3);
	recipe.AddIngredient(ItemID.Wire,200);
	recipe.AddIngredient(ItemID.Explosives,5);
	recipe.AddIngredient(ItemID.IronBar,20);
	recipe.AddTile(TileID.MythrilAnvil);
	recipe.SetResult(this,1);
	recipe.AddRecipe();
       }
      
         
   }

}
