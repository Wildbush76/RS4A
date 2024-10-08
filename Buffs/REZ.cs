using RS4A.Biomes;
using RS4A.PlayerStuff;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Buffs
{
    public class REZ : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true; //you're TELLIN ME
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.InModBiome<BrazilSurfaceBiome>() || player.InModBiome<BrazilUndergroundBiome>())
            {
                player.buffTime[buffIndex] = 10; // reset buff time
            }
            //player.poisoned = true;
            RSPlayer modPlayer = player.GetModPlayer<RSPlayer>();
            modPlayer.radioactive = true;
            modPlayer.DOT -= 30;//i like to damage player you just do negitive regen.

        }
    }
}

