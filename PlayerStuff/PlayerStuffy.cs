
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using RS4A.Items;
using RS4A.Projectiles;
using Terraria.Chat;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace RS4A.PlayerStuff
{
    public class PlayerStuffy : ModPlayer
    {
        public override void OnHurt(Player.HurtInfo info) 
        {
            base.OnHurt(info);
            int hydrogenBombItem = ModContent.ItemType<HydrogenBomb>();
            int hydrogenBombProjectile = ModContent.ProjectileType<HydrogenBombProjectile>();

            if (Player.HasItem(hydrogenBombItem))
            {
                Random russianRoulette = new();
                int yes = russianRoulette.Next(1, 8);
                if (yes==1)
                { //you lose
                    ChatHelper.SendChatMessageToClient(NetworkText.FromLiteral("YOU LOSE!!!!!"), Color.Green, Main.myPlayer);
                    for (int i=0; i<Player.CountItem(hydrogenBombItem); i++)
                    {
                        Player.ConsumeItem(hydrogenBombItem);
                    }
                    //Projectile.NewProjectile(Player,Player.position,new Vector2(0,0), hydrogenBombProjectile);
                }
            }
        }
    }

}