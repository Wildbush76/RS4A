using RS4A.PlayerStuff;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Buffs
{
    public class Radiation3 : ModBuff
    {
        //this is for npcs
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff

        }
        public override void Update(Player player, ref int buffIndex)
        {
            RSPlayer modPlayer = player.GetModPlayer<RSPlayer>();
            modPlayer.DOT -= 30;//i like to damage player you just do negitive regen.
            modPlayer.radioactive = true;

        }
    }
}
