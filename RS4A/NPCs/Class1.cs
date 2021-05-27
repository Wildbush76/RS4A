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
		public override void GetChat(NPC npc, ref string chat)
		{
			DateTime today = DateTime.Today;
			if (today.ToString("d").Remove(today.ToString("d").Length - 5) == "6/2")
			{

				switch (Main.rand.Next(3))
				{
					case 0:
						chat = "oh happy birthday";
						break;
					case 1:
						chat = "congrats your closer to death";
						break;
					default:
						chat = "HAPPY BIRTHDAY";
						break;

				}
			}
		}

	}
}
