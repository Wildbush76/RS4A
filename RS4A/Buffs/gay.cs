using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Buffs
{
    public class gay : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Gay");
            Description.SetDefault("your gay now");
        }
        public override void Update(Player player, ref int buffIndex)
        {
        
        }
        
    }
}
