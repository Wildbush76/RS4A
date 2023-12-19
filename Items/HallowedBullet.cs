using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class HallowedBullet : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.ChlorophyteBullet;
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 7;
            Item.height = 13;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.knockBack = 1.2f;
            Item.rare = ItemRarityID.Blue;
            Item.shoot = ModContent.ProjectileType<Projectiles.HallowedBullet>();
            Item.shootSpeed = 8.5f;
            Item.ammo = AmmoID.Bullet;

        }
    }
}
