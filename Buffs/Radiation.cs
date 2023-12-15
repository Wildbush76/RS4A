using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Buffs
{
    public class Radiation : ModBuff
    {
        //this is for npcs
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen -= 200;//i like to damage player you just do negitive regen.
            player.moveSpeed += 10f;
            player.GetDamage(DamageClass.Generic) += 20; //wait wait wait wait wait... you gain 2000% more damage from this???????????????????????????? lol im keeping that
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen -= 200;
           
        }
    }
}
