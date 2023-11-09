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
            // DisplayName.SetDefault("Uranium ore");
            // Tooltip.SetDefault("Glowing green rock");
        }
        public override void SetDefaults()
        {

            Item.width = 8;
            Item.height = 8;
            Item.consumable = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.createTile = Mod.Find<ModTile>("Uranium").Type;
            Item.maxStack = 999;
            Item.autoReuse = true;
        }

    }

}
