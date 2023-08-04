using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Buffs
{
    public class Rad : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Radatiom");
            Description.SetDefault("Radation is not fun, lose much heath you do");
            canBeCleared = false;
 
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen -= 200;//i like to damage player you just do negitive regen.
            player.moveSpeed += 10f;
            player.allDamage += 20;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen -= 200;
        }
    }
}
