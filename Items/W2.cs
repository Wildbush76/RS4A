using RS4A.PlayerStuff;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;

namespace RS4A.Items
{
    internal class W2 : ModItem
    {
        private int TaxesPaid
        {
            get;

            set
            {
                field = value;
                Item.damage = value / (10000);
                Item.ToolTip = ItemTooltip.FromLocalization(Language.GetText("Mods.RS4A.Taxes.W2").WithFormatArgs(value / 100));
            }
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.PaperAirplaneA);

        }

        public override void OnCreated(ItemCreationContext context)
        {
            if (context is BuyItemCreationContext)
            {
                Income income = Main.LocalPlayer.GetModPlayer<Income>();
                TaxesPaid = income.OwedTaxes;
                income.income = 0;

            }
        }

        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("Value"))
                TaxesPaid = tag.GetInt("Value");
            else
                TaxesPaid = 0;

        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("Value", TaxesPaid);
        }

    }
}
