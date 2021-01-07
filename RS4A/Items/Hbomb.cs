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
			DisplayName.SetDefault("H Bomb");
			Tooltip.SetDefault("is very large bomb");
		}
        public override void SetDefaults()
		{
				
			item.width = 8;
			item.height = 8;
			item.consumable = true;
			item.useStyle = 1;
			item.useTime = 20;
			item.useAnimation = 20;
			item.createTile = mod.TileType("H_Bomb");
			item.maxStack = 1;
			item.autoReuse = false;
		}
         
   }

}