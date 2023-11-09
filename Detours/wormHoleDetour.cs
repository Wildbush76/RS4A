using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace RS4A.Detours
{
    internal class wormHoleDetour : ModSystem
    {
        public override void Load() {
            On_Player.HasUnityPotion += On_Player_HasUnityPotion;
            On_Player.TakeUnityPotion += On_Player_TakeUnityPotion;
        }

        private void On_Player_TakeUnityPotion(On_Player.orig_TakeUnityPotion orig, Player self)
        {
            if (self.HeldItem.type.Equals(ModContent.ItemType<Items.Nuke>()))
            {
                self.QuickSpawnItem(self.GetSource_FromAI(), 200);
                return;
            }
            else
            {
                orig(self);
            }
        }

        private bool On_Player_HasUnityPotion(On_Player.orig_HasUnityPotion orig, Player self)
        {
            return self.HeldItem.type.Equals(ModContent.ItemType<Items.Nuke>());
        }
    }
}
