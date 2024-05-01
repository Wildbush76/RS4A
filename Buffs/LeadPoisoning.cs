using RS4A.PlayerStuff;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Buffs
{
    public class LeadPoisoning : ModBuff
    {
        //this is for npcs
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            RSPlayer modPlayer = player.GetModPlayer<RSPlayer>();
            modPlayer.radioactive = true;
            modPlayer.leadPoisoned = true; // makes you immune to radiation btw
            player.brokenArmor = true; //half-defense
            player.GetDamage(DamageClass.Generic) -= 0.2f; //-20% damage
            player.confused = true; //lead poisoning lol
            player.moveSpeed -= 0.2f;

            // immune to all forms of radiation

            player.buffImmune[ModContent.BuffType<Radiation>()] = true;
            player.buffImmune[ModContent.BuffType<Radiation2>()] = true;
            player.buffImmune[ModContent.BuffType<Radiation3>()] = true;
            player.buffImmune[ModContent.BuffType<REZ>()] = true;

        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen -= 200;

        }
    }
}
