using RS4A.Tiles;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace RS4A.Generation
{
    public class UraniumGeneration : GenPass
    {
        public UraniumGeneration(string name, float loadWeight) : base(name, loadWeight)
        {
            //this is where the actual stuff happens btw
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "I LOVE URANIUM!!!!!!!!!!!";
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++) //not copy and pasted :)
            {

                int x = WorldGen.genRand.Next(0, Main.maxTilesX);

                int y = WorldGen.genRand.Next((int)GenVars.rockLayer, Main.maxTilesY); //we could use other layers like rockLayerLow but that's up to you

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<UraniumOre>());

            }
        }
    }
}
