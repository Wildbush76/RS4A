

using RS4A.Items;
using System;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.NPCs
{
    public class Npc : GlobalNPC
    {
        static int rng = 0;
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.WitchDoctor)
            {
                shop.Add(ItemID.Bottle);

                shop.Add(new Item(ModContent.ItemType<ArmyPotion>())
                {
                    shopCustomPrice = 80000000

                });
            }
            DateTime today = DateTime.Today;
            if (today.Day == 2 && today.Month == 6)
            {

                for (int a = 0; a < shop.Entries.Count; a++)
                {
                    shop.Entries.ElementAt(a).Item.value = shop.Entries.ElementAt(a).Item.value /= 2; //i have not fucking clue if this will work lmao
                }
            }
        }


        public override void GetChat(NPC npc, ref string chat)
        {
            DateTime today = DateTime.Today;
            if (today.Day == 2 && today.Month == 6)
            {

                switch (Main.rand.Next(4))
                {
                    case 0:
                        chat = "oh happy birthday";
                        break;
                    case 1:
                        chat = "congrats your one year closer to death";
                        break;
                    case 2:
                        chat = "Happy birthday my boy, half off prices for ye";
                        break;
                    case 3:
                        chat = "your getting old you sure ye can still fight them bosses"; //lol
                        break;

                }
            }
            if (npc.type == NPCID.SkeletonMerchant)
            {
                rng = Main.rand.Next(10);
                if (rng == 0)
                {
                    chat = "I did your mother, " + Main.LocalPlayer.name.ToString() + ".";

                }
            }
        }

        public override bool PreChatButtonClicked(NPC npc, bool firstButton)
        {
            if (npc.type == NPCID.SkeletonMerchant && rng == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Lihzahrd || npc.type == NPCID.LihzahrdCrawler)
            {
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.DownedPlantera(), ModContent.ItemType<MushuWhip>(), 100));
            }
        }

    }
}
