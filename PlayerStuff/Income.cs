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
        private static readonly Tuple<int, float>[] taxes = [//assuming filing as single, based of IRS website
            new(11925,0.1f),
            new(48475,0.12f),
            new(103350,0.22f),
            new(197300,0.24f),
            new(250525,0.32f),
            new(626350,0.35f)
            ];
        public int OwedTaxes {
            get  {
                float money = income/100f;//assume 1silver = $1
                float taxes = 0;

                int bracket = 0;
                while (money > 0 && bracket < Income.taxes.Length) {
                    taxes += Math.Min(Income.taxes[bracket].Item1, money) * Income.taxes[bracket].Item2;
                    money -= Income.taxes[bracket].Item1;
                }
                taxes += Math.Max(0, money) * 0.37f;//final tax on remaining income
                return (int)Math.Ceiling(taxes * 100); ///multiplied by 100 to convert back into terraria money
            }
            
        }

        public int income ;

        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("Income")) {
                income = tag.GetAsInt("Income");
            }
        }

        public override void SaveData(TagCompound tag)
        {
            
            tag.Add("Income", income);
        }
    }
}
