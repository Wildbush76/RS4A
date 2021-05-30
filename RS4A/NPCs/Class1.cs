using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using RS4A.Items;

namespace RS4A.NPCs
{
   public class npc : GlobalNPC
    {
    static int rng = 0;
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{

			if (type == NPCID.WitchDoctor)
			{
				shop.item[nextSlot].SetDefaults(ItemID.Bottle);
				nextSlot++;
			} else if (type == NPCID.SkeletonMerchant)
			{
				shop.item[nextSlot].SetDefaults(ItemID.BoneKey);
				shop.item[nextSlot].shopCustomPrice = 500000; //in copper, of course
				nextSlot++;
			}
			DateTime today = DateTime.Today;
			if (today.Day == 2 && today.Month==6)
			{
				if(type == NPCID.PartyGirl)
                {
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<Tnurse>());
					shop.item[nextSlot].shopCustomPrice = 100;
                }
				for (int a = 0; a<shop.item.Length;a++)
                {
					shop.item[a].shopCustomPrice = shop.item[a].value / 2;
                }
			}	
		}
		public override void GetChat(NPC npc, ref string chat)
		{
			DateTime today = DateTime.Today;
			if (today.Day == 2 && today.Month == 6)
			{

				switch (Main.rand.Next(3))
				{
					case 0:
						chat = "oh happy birthday";
						break;
					case 1:
						chat = "congrats your on year closer to death";
						break;
					default:
						chat = "HAPPY BIRTHDAY";
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
			} else
            {
				return true;
			}
		}

	}
}
