using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Buffs
{
    public class Gay : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.persistentBuff[Type] = true;
            // DisplayName.SetDefault("Gay");
            // Description.SetDefault("your gay now, deal with it");
            
        }
        public override void Update(Player player, ref int buffIndex)
        {
         
        }
        
    }
}
