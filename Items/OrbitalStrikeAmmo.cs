using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    internal class OrbitalStrikeAmmo : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.None;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Red;
            Item.ammo = AmmoID.None;
        }
    }
}
