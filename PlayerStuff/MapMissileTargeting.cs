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
                mouseText = "middle click to fire missiles";

                if (Main.mouseMiddle)
                {
                    
                    if (!pressed)
                    {
                      
                        Vector2 cursorPosition = new(Main.mouseX, Main.mouseY);

                        cursorPosition.X -= Main.screenWidth / 2f;
                        cursorPosition.Y -= Main.screenHeight / 2f;

                     
                        Vector2 cursorWorldPosition = Main.mapFullscreenPos;

                        cursorPosition /= 16f;
                        cursorPosition *= 16f / Main.mapFullscreenScale;
                        cursorWorldPosition += cursorPosition;
                        cursorWorldPosition *= 16f;

                        if (missileRemote.FireMissile(cursorWorldPosition)) { 
                           // Main.mapFullscreen = false;
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
