using Microsoft.Xna.Framework;
using RS4A.Items;
using RS4A.RS4AUtils;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace RS4A.PlayerStuff
{


    internal class MissileSystem : ModSystem
    {
        public static readonly List<MissileLaunchInfo> missilesToLaunch = [];
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
                    Vector2 cursorPosition = new(Main.mouseX, Main.mouseY);

                    cursorPosition.X -= Main.screenWidth / 2f;
                    cursorPosition.Y -= Main.screenHeight / 2f;


                    Vector2 cursorWorldPosition = Main.mapFullscreenPos;

                    cursorPosition /= 16f;
                    cursorPosition *= 16f / Main.mapFullscreenScale;
                    cursorWorldPosition += cursorPosition;
                    cursorWorldPosition *= 16f;

                    if (missileRemote.FireMissile(cursorWorldPosition))
                    {
                        Main.mapFullscreen = false;
                    }
                }

            }
        }

        public override void PreUpdateWorld()
        {
            for (int i = missilesToLaunch.Count - 1; i >= 0; i--) 
            {
                MissileLaunchInfo info = missilesToLaunch[i];
                if (--info.timer <= 0)
                {
                    Tile tile = Main.tile[info.siloLocation];
                    if (TileLoader.GetTile(tile.TileType) is Tiles.MissileSilo)
                    {
                        Tiles.MissileSilo.Launch(info.siloLocation.X, info.siloLocation.Y, info.target);
                    }
                    missilesToLaunch.RemoveAt(i);
                }

            }
        }
    }
}
