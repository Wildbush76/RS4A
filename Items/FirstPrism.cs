using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace RS4A.Items
{
    public class FirstPrism : ModItem
    {
        public static Color OverrideColor = new(100,100,100);

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LastPrism);
            Item.shoot = ModContent.ProjectileType<Projectiles.FirstPrismHoldout>();
            Item.color = OverrideColor;
        }


        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.FirstPrismHoldout>()] <= 0;
        }
      
    }
}
