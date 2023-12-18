using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


//TODO finish making the rocket launcher
namespace RS4A.Items
{
    internal class LockOnRocketLauncher : ModItem
    {
        private Projectile targeting = null;
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
            /*
               if(targeting == null || !targeting.active)
               {
                   targeting = Projectile.NewProjectileDirect(player.GetSource_FromThis(),player.position,Vector2.Zero,ModContent.ProjectileType<Projectiles.RocketLauncherTargeting>(),0,0);
                   ChatHelper.SendChatMessageToClient(NetworkText.FromLiteral("Spawning the targeting"), Color.Red, Main.myPlayer);
               }
            */
        }

        public override bool? UseItem(Player player)
        {
            /*
            if(player.whoAmI != Main.myPlayer) {
                return null; 
            }

            //set target tracking
            return null;
            */
            return null;
        }

    }
}
