using RS4A.PlayerStuff;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Detours
{
    internal class IncomeDetour : ModSystem

    {

        public override void Load()
        {
            On_Player.PickupItem += On_Player_PickupItem;
        }

        private Item On_Player_PickupItem(On_Player.orig_PickupItem orig, Player self, int playerIndex, int worldItemArrayIndex, Item itemToPickUp)
        {
            if (itemToPickUp.IsACoin)
            {
                Income income = self.GetModPlayer<Income>();

                long pickedUpCoinValue = 0;

                switch (itemToPickUp.type)
                {
                    case ItemID.CopperCoin:
                        pickedUpCoinValue += itemToPickUp.stack * 1;
                        break;
                    case ItemID.SilverCoin:
                        pickedUpCoinValue += itemToPickUp.stack * 100;
                        break;

                    case ItemID.GoldCoin:
                        pickedUpCoinValue += itemToPickUp.stack * 100000;
                        break;
                    case ItemID.PlatinumCoin:
                        pickedUpCoinValue += itemToPickUp.stack * 100000000;
                        break;

                }

                income.income += pickedUpCoinValue;
            }


            return orig(self, playerIndex, worldItemArrayIndex, itemToPickUp);

        }


    }
}
