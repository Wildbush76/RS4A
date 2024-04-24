using Microsoft.Xna.Framework;
using RS4A.Items;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace RS4A.Tiles
{
    public class MissileSilo : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLavaDeath[Type] = false;

            Main.tileFrameImportant[Type] = true;
           

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new[] {16,16,16,16 };
            TileObjectData.addTile(Type);
     
            AddMapEntry(new Color(100,100,100));

            MinPick = 100;
        }

        public static void ToggleMissile(int i, int j, bool dropItem = true) {
            Tile tile = Main.tile[i,j];
            int topY = j - (tile.TileFrameY / 18) % 4;
            int topX = i - (tile.TileFrameX / 18) % 2;


            short frameAdjust;
            if (tile.TileFrameX > 18)
            {
                frameAdjust = -36;
                if(dropItem)
                    Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i,j), new Rectangle(i * 16,j * 16,32,64), ModContent.ItemType<Missile>());
            }
            else {
                frameAdjust = 36;
            }
            for (short xOffset = 0; xOffset < 2; xOffset++)
            {
                for (short yOffset = 0; yOffset < 4; yOffset++)
                {
                    Main.tile[topX + xOffset, topY + yOffset].TileFrameX += frameAdjust;
                }
            }
        }

        public void launch(int i, int j, Point16 target) {
            if (Main.tile[i,j].TileFrameX > 18) {
                ToggleMissile(i, j, false);
            }
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Item item = player.HeldItem;
            bool loaded = Main.tile[i, j].TileFrameX > 18;

            if(item.ModItem is MissileRemote missileRemote)
            {
                missileRemote.addLaunchLocation(new Point16(i, j));
            }

            else if (item.ModItem is Missile ^ loaded)
            {
                item.stack--;
                ToggleMissile(i, j);
                return true;
            }
            
            return false;
        }
    }
}