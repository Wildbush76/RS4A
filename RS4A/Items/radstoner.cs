using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RS4A.Items
{
   public class radstoner : ModItem
  {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Radioactive stone");
		//	Tooltip.SetDefault("  ");
		}
        public override void SetDefaults()
		{
				
			item.width = 8;
			item.height = 8;
			item.consumable = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTime = 10;
			item.useAnimation = 10;
			item.createTile = mod.TileType("radstone");
			item.maxStack = 999;
			item.autoReuse = true;
		}
         
   }

}
