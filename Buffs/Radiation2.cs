using RS4A.PlayerStuff;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Buffs
{
    public class Radiation2 : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true; //you're TELLIN ME
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            //player.poisoned = true;
            RSPlayer modPlayer = player.GetModPlayer<RSPlayer>();
            modPlayer.DOT -= 45;//i like to damage player you just do negitive regen.
            modPlayer.radioactive = true;

        }

    }
}

