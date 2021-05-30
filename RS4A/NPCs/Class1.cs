using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace RS4A.NPCs
{
   public class npc : GlobalNPC
    {
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{

			if (type == NPCID.WitchDoctor)
			{
				shop.item[nextSlot].SetDefaults(ItemID.Bottle);
				nextSlot++;
			}
			DateTime today = DateTime.Today;
			if (today.Day == 2 && today.Month==6)
			{
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
		}

	}
}
