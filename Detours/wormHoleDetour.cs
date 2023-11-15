using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.ModLoader;

namespace RS4A.Detours
{
    internal class WormHoleDetour : ModSystem
    {
        public override void Load()
        {
            On_Player.HasUnityPotion += On_Player_HasUnityPotion;
            On_Player.TakeUnityPotion += On_Player_TakeUnityPotion;
            On_Player.UnityTeleport += On_Player_UnityTeleport;
        }

        private void On_Player_UnityTeleport(On_Player.orig_UnityTeleport orig, Player self, Vector2 telePos)
        {
            if (self.HeldItem.type.Equals(ModContent.ItemType<Items.OrbitalStrike>()))
            {
                //find the player
                double closest = double.MaxValue;
                Player closestPlayer = null;
                for (int i = 0; i < Main.maxPlayers; i++)
                {
                    Player player = Main.player[i];
                    if (player.active && !player.dead)
                    {
                        double dist = Vector2.Distance(telePos, player.Center);
                        if (dist < closest)
                        {
                            closest = dist;
                            closestPlayer = player;
                        }
                    }
                }
                if (closestPlayer == null)
                {
                    return;
                }
                else if (closestPlayer.ZoneOverworldHeight)
                {
                    if (CheckForItemInInvetory(self, self.HeldItem.useAmmo))
                    {
                        //use the ammo
                        for (int slot = 0; slot < Main.player[Main.myPlayer].inventory.Length; slot++)
                        {
                            Item item = Main.player[Main.myPlayer].inventory[slot];
                            if (item.type == self.HeldItem.useAmmo)
                            {
                                item.stack -= 1;
                                if (item.stack <= 0)
                                {
                                    item.TurnToAir();
                                }
                            }
                        }
                        Projectile.NewProjectile(closestPlayer.GetSource_FromThis(), closestPlayer.Center + new Vector2(Main.screenWidth, Main.screenHeight), Vector2.Zero, ModContent.ProjectileType<Projectiles.TargetedForOrbitalStrike>(), 0, 0, ai0: closestPlayer.whoAmI);
                    }
                    else
                    {
                        ChatHelper.SendChatMessageToClient(NetworkText.FromLiteral("Insufficent nuclear fuel rods to use an Orbital Strike"), Color.Red, Main.myPlayer);
                    }
                }

                else
                {
                    ChatHelper.SendChatMessageToClient(NetworkText.FromLiteral("Orbital strikes can only occur to players on the surface layer"), Color.Red, Main.myPlayer);
                }
            }
            else
            {
                orig(self, telePos);
            }
        }

        private void On_Player_TakeUnityPotion(On_Player.orig_TakeUnityPotion orig, Player self)
        {
            if (self.HeldItem.type.Equals(ModContent.ItemType<Items.OrbitalStrike>()))
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
            if (self.HeldItem.type.Equals(ModContent.ItemType<Items.OrbitalStrike>()) && CheckForItemInInvetory(self, self.HeldItem.useAmmo))
            {
                return true;
            }
            else
            {
                return orig(self);
            }
        }

        private static bool CheckForItemInInvetory(Player self, int itemType)
        {
            foreach (Item item in self.inventory)
            {
                if (item.type == itemType)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
