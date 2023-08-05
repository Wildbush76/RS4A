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
        //this is what happens if you touch uranium. rad stone is weaker
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Weak Radation");
            // Description.SetDefault("Radation is not fun, lose much heath you do");
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;


        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen -= 200;//i like to damage player you just do negitive regen.
            player.moveSpeed += 10f;
            player.GetDamage(DamageClass.Generic) += 20;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen -= 200;
        }
    }
}
