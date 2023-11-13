using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    internal class LockOnRocketLauncher : ModItem
    {
        private Projectile targeting;
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAmmo = AmmoID.Rocket;
            Item.rare = ItemRarityID.Red;
            Item.useTime = 80;
            Item.useAnimation = 80;
            Item.channel = true;
        }

        public override void HoldItem(Player player)
        {
            if (targeting != null)
            {
                //something
            }
            else
            {
                targeting = Projectile.NewProjectileDirect(player.GetSource_FromThis(),player.position,Vector2.Zero,1,0,0);
            }
        }

        public override bool? UseItem(Player player)
        {
            if(player.whoAmI != Main.myPlayer) {
                return null; 
            }

            //set target tracking
            return null;
        }

    }
}
