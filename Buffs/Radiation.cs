using RS4A.PlayerStuff;
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
            RSPlayer modPlayer = player.GetModPlayer<RSPlayer>();
            modPlayer.DOT -= 200;//i like to damage player you just do negitive regen.
            modPlayer.radioactive = true;
            player.moveSpeed += 10f;
            player.GetDamage(DamageClass.Generic) += 20; //wait wait wait wait wait... you gain 2000% more damage from this???????????????????????????? lol im keeping that
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen -= 200;
           
        }
    }
}
