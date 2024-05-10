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
            player.GetDamage(DamageClass.Generic);// += 0.5; // nerfed to 50%, i could one shot most bosses with it
        }
    }
}
