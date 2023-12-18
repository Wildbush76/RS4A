using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class FakeSDMG : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.SDMG;
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SDMG);
            Item.damage = 5;
            Item.shootSpeed = 200;
            Item.shoot = ModContent.ProjectileType<Projectiles.ShootYourselfBullets>();
            
        }
        public override void SetStaticDefaults()
        {
            
        }
    }
}
