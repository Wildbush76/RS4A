using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RS4A.Items
{
   public class Uranium_or : ModItem
  {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Uranium ore");
			Tooltip.SetDefault("Glowing green rock");
		}
        public override void SetDefaults()
		{
				
			item.width = 8;
			item.height = 8;
			item.consumable = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTime = 10;
			item.useAnimation = 10;
			item.createTile = mod.TileType("Uranium");
			item.maxStack = 999;
			item.autoReuse = true;
		}
         
   }

}
