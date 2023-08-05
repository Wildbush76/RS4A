
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

namespace RS4A.PlayerStuff
{
    public class PlayerStuffy : ModPlayer
    {
        public bool leeroyActive;
        public override void ResetEffects()
        {
            leeroyActive = false;
        }
        public override void PostUpdateEquips() //this is for leeroy emblem
        {
            if (leeroyActive) {
                if (Player.statDefense<100 && Player.endurance<0.50f)
                { //100 is the range
                  //player.GetDamage(DamageClass.Generic) += player.statDefense; //this equation is dogshit
                    Player.GetDamage(DamageClass.Generic) += 2f * ((100f - Player.statDefense) / 100f) * ((0.50f - Player.endurance) * 2f); //maximum of 200% damage (no defense, hard to do at post-moonlord as armor and accessories start giving the good stuff)
                }
            }
        }
    }

}