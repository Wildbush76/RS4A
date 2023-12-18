using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class FirstPrism : ModItem
    {
        public static Color OverrideColor = new(200, 200, 200);


        public override void SetStaticDefaults()
        {
            ItemID.Sets.ShimmerTransformToItem[ItemID.LastPrism] = Type;
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LastPrism);
            Item.shoot = ModContent.ProjectileType<Projectiles.FirstPrismHoldout>();
            Item.color = OverrideColor;
            Item.damage = 5;
        }


        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.FirstPrismHoldout>()] <= 0;
        }

    }
}
