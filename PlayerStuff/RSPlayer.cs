
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
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Localization;
using Humanizer;

namespace RS4A.PlayerStuff
{
    public class RSPlayer : ModPlayer
    {
        public bool isDOT;
        public bool leadPoisoned;
        public bool radioactive; // only exists for death messages i think :)
        public int DOT;
        private string deathMessages = "Mods.RS4A.Status.Death";

        public override void ResetEffects()
        {
            leadPoisoned = false;
            radioactive = false;
            DOT = 0;
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) // copied from calamity, why does damage == 10?
            {
                if (radioactive)
                {
                    damageSource = PlayerDeathReason.ByCustomReason(Language.GetTextValue(deathMessages + ".Radiation-" + Main.rand.Next(1, 4)).FormatWith(Player.name));
                }
            }


            return true;
        }
        public override void UpdateBadLifeRegen()
        {
            if (DOT<0)
            {
                // These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects
                if (Player.lifeRegen > 0)
                    Player.lifeRegen = 0;
                // Player.lifeRegenTime used to increase the speed at which the player reaches its maximum natural life regeneration
                // So we set it to 0, and while this debuff is active, it never reaches it
                Player.lifeRegenTime = 0;
                // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second
                Player.lifeRegen += DOT;
            }
        }
    }

}