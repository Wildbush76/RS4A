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
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Radatiom");
            Description.SetDefault("Radation is not fun, lose much heath you do");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.poisoned = true;
            player.lifeRegen -= 200;
            player.moveSpeed -= .7f;
            player.allDamage += 5;
        }
        // idk how tf to do this
        //ill add stuf later for now it does nothing
    }
}
