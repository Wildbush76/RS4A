using Microsoft.Xna.Framework;
using RS4A.Items;
using RS4A.Projectiles;
using Terraria;
using Terraria.DataStructures;
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
            Main.tileSolid[Type] = false;


            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);

            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 18 };
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(100, 100, 100));
            MinPick = 100;
        }

       

        private static Point16 GetTop(int i, int j)
        {

            Tile tile = Main.tile[i, j];
            int topY = j - (tile.TileFrameY / 18) % 4;
            int topX = i - (tile.TileFrameX / 18) % 2;
            return new Point16(topX, topY);
        }

        public static void ToggleMissile(int i, int j, bool dropItem = true)
        {
            Tile tile = Main.tile[i, j];

            Point16 top = GetTop(i, j);



            short frameAdjust;
            if (tile.TileFrameX > 18)
            {
                frameAdjust = -36;
                if (dropItem)
                    Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), new Rectangle(i * 16, j * 16, 32, 64), ModContent.ItemType<Missile>());
            }
            else
            {
                frameAdjust = 36;
            }
            for (short xOffset = 0; xOffset < 2; xOffset++)
            {
                for (short yOffset = 0; yOffset < 4; yOffset++)
                {
                    Main.tile[top.X + xOffset, top.Y + yOffset].TileFrameX += frameAdjust;
                }
            }
        }

        public static void Launch(int i, int j, Vector2 target)
        {
            if (Main.tile[i, j].TileFrameX > 18)
            {
                ToggleMissile(i, j, false);
                Point16 top = GetTop(i, j);
                Projectile.NewProjectile(Main.player[Main.myPlayer].GetSource_FromAI(), new Vector2((top.X + 1) * 16 - 10, (top.Y + 2) * 16), Vector2.Zero, ModContent.ProjectileType<MissileProjectile>(), 300, 10, ai0: target.X, ai1: target.Y);
            }
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Item item = player.HeldItem;
            bool loaded = Main.tile[i, j].TileFrameX > 18;

            if (item.ModItem is MissileRemote missileRemote)
            {
                missileRemote.AddLaunchLocation(GetTop(i, j));
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