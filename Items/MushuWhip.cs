using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class MushuWhip : ModItem
    {

        public override string Texture => "Terraria/Images/Item_" + ItemID.BlandWhip;
        public override void SetDefaults()
        {
            Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.MushuWhipProjectile>(), 30, 10, 10, 30);

        }

    }


}
