using RS4A.Tiles;
using System;
using Terraria.ModLoader;

namespace RS4A.Biomes.BlockCount
{
    public class BrazilBiomeTileCount : ModSystem
    {
        public int brazilBlockCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            brazilBlockCount = tileCounts[ModContent.TileType<RadioactiveStone>()]; //lol
        }
    }
}