using RS4A.Tiles;
using System;
using Terraria.ModLoader;

namespace RS4A.Biomes.BlockCount
{
    public class ExampleBiomeTileCount : ModSystem
    {
        public int exampleBlockCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            exampleBlockCount = tileCounts[ModContent.TileType<RadioactiveStone>()]; //lol
        }
    }
}