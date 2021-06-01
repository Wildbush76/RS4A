﻿using Terraria;
using Terraria.ModLoader;

namespace death.Buffs
{
    public class army : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Army Recruiter");
            Description.SetDefault("You can recruit many more men to your cause!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.maxMinions += 100;
        }
    }
}