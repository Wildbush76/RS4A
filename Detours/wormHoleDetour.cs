using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.CodeAnalysis;
using Terraria.ID;

namespace RS4A.Detours
{
    internal class wormHoleDetour : ModSystem
    {
        public override void Load() {
            On_Player.HasUnityPotion += On_Player_HasUnityPotion;
            On_Player.TakeUnityPotion += On_Player_TakeUnityPotion;
            On_Player.UnityTeleport += On_Player_UnityTeleport;
        }

        private void On_Player_UnityTeleport(On_Player.orig_UnityTeleport orig, Player self, Vector2 telePos)
        {
            if (self.HeldItem.type.Equals(ModContent.ItemType<Items.OrbitalTargeter>()))
            {
                //find the player
                double closest = double.MaxValue;
                Player closestPlayer = null;
                for (int i = 0; i < Main.maxPlayers; i++) {
                    Player player = Main.player[i];
                    if (player.active && !player.dead) {
                        double dist = Vector2.Distance(telePos, player.Center);
                        if (dist < closest) {
                            closest = dist;
                            closestPlayer = player;
                        }
                    }
                }
                if (closestPlayer == null)
                {
                    return;
                }
                else
                {
                    closestPlayer.AddBuff(ModContent.BuffType<Buffs.OrbitalStrike>(), 200,false);
                }
            }
            else {
                orig(self,telePos);
            }
        }

        private void On_Player_TakeUnityPotion(On_Player.orig_TakeUnityPotion orig, Player self)
        {
            if (self.HeldItem.type.Equals(ModContent.ItemType<Items.OrbitalTargeter>()))
            {
                return;
            }
            else
            {
                orig(self);
            }
        }

        private bool On_Player_HasUnityPotion(On_Player.orig_HasUnityPotion orig, Player self)
        {
            if (self.HeldItem.type.Equals(ModContent.ItemType<Items.OrbitalTargeter>()))
            {
                return true;
            }
            else {
                return orig(self);
            }
        }
    }
}
