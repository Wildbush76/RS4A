﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    internal class MissileSilo : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 70;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.createTile = ModContent.TileType<Tiles.MissileSilo>();
            Item.maxStack = 5;
            Item.consumable = true;
        }
    }
}
