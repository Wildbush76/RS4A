using Microsoft.Xna.Framework;
using RS4A.Items;
using Terraria;
using Terraria.ModLoader;

namespace RS4A.PlayerStuff
{
    internal class MapMissileTargeting : ModSystem
    {
        private bool pressed = false;
        public override void PostDrawFullscreenMap(ref string mouseText)
        {


            Player player = Main.player[Main.myPlayer];
            if (!Main.mapFullscreen)
                return;
            if (player.HeldItem.ModItem is MissileRemote missileRemote)
            {
                mouseText = "target location?";

                if (Main.mouseRight)
                {
                    if (!pressed)
                    {
                        Vector2 cursorPosition = new(Main.mouseX, Main.mouseY);

                        cursorPosition.X -= Main.screenWidth / 2;
                        cursorPosition.Y -= Main.screenHeight / 2;

                        Vector2 mapPosition = Main.mapFullscreenPos;
                        Vector2 cursorWorldPosition = mapPosition;

                        cursorPosition /= 16;
                        cursorPosition *= 16 / Main.mapFullscreenScale;
                        cursorWorldPosition += cursorPosition;

                        if (missileRemote.FireMissile(cursorWorldPosition * 16)) { 
                            Main.mapFullscreen = false;
                        }
                        pressed = true;
                    }
                }
                else
                {
                    pressed = false;
                }
            }
        }
    }
}
