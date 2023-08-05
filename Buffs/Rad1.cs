using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Buffs
{
    public class Rad1 : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Radatiom");
            // Description.SetDefault("Radation is not fun, lose much heath you do");
            Main.debuff[Type] = true; //you're TELLIN ME
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            //player.poisoned = true;
            player.lifeRegen -= 25;//i like to damage player you just do negitive regen.
           
        }

    }
}

