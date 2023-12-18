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
    public class ODMSwords : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.BreakerBlade;
        private const int ODM_EQUIPPED_BONUS = 50;
        private const float DAMAGE_SPEED_SCALE = 0.1f;
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BreakerBlade);
            Item.damage = 20;
            Item.useTime = 20;
            Item.useAnimation = 5;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.crit = 20;
            Item.holdStyle = ItemHoldStyleID.HoldFront;
        }

        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            Item.damage += (int)(Vector2.Distance(Vector2.Zero, player.velocity) * DAMAGE_SPEED_SCALE);
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.ODM>()] > 0) {   
                Item.damage *= ODM_EQUIPPED_BONUS;
            }
        }

    }
}
