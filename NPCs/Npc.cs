
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using RS4A.Items;
using RS4A.Projectiles;

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
                    shopCustomPrice = 80000000 //in copper
                });
            }
            DateTime today = DateTime.Today;
            if (today.Day == 2 && today.Month == 6)
            {
    
                for (int a = 0; a < shop.Entries.Count; a++)
                {
                    shop.Entries.ElementAt(a).Item.value = shop.Entries.ElementAt(a).Item.value / 2; //i have not fucking clue if this will work lmao
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
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            if (npc.HasBuff(BuffID.Venom))
            {
                modifiers.SetCrit(); //i think?
            }
        }

    }
}
