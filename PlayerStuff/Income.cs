using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace RS4A.PlayerStuff
{
    internal class Income : ModPlayer
    {
        public long income;

        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("Income")) {
                income = tag.GetAsLong("Income");
            }
        }

        public override void SaveData(TagCompound tag)
        {
            
            tag.Add("Income", income);
        }
    }
}
