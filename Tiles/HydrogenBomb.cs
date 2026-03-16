using Microsoft.Xna.Framework;
using RS4A.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace RS4A.Tiles
{


    internal class HydrogenBomb : ModTile
    {
        const int TileWidth = 2;
        const int TileHeight = 3;

        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileLavaDeath[Type] = false;
            Main.tileFrameImportant[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.CoordinateHeights = [16, 16];
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 0;

            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.AnchorBottom = new AnchorData(Terraria.Enums.AnchorType.SolidTile, TileObjectData.newTile.Width, 0);

            TileObjectData.addTile(Type);

            AddMapEntry(new Color(255, 255, 0));

        }

        public override bool IsTileDangerous(int i, int j, Player player)
        {
            return true;
        }

        public override void HitWire(int i, int j)
        {
            (int x, int y) = TileObjectData.TopLeft(i, j);
            for (int yy = y; yy < y + TileHeight; yy++)
            {
                for (int xx = x; xx < x + TileWidth; xx++)
                {
                    Wiring.SkipWire(xx, yy);
                }
            }

            CreateExplosion(x, y);
        }

        private static void CreateExplosion(int x, int y)
        {
            float spawnX = (x + TileWidth * 0.5f) * 16;
            float spawnY = (y + TileHeight * 0.65f) * 16;
            var source = new EntitySource_TileUpdate(x, y, "HydrogenBomb");
            Projectile.NewProjectile(source, spawnX, spawnY, 0, 0, ModContent.ProjectileType<HydrogenBombExplosion>(), 0, 0);

        }
    }
}
