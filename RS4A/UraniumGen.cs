using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using System.Collections.Generic;
using Terraria.GameContent.Generation;
using static Terraria.ModLoader.ModContent;

namespace TMMCWorld
{
    public class TMMCWorld : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(x => x.Name.Equals("Shinies"));
            if (shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new PassLegacy("TMMC Ore Generation", OreGeneration));
            }
            
        }

        private void OreGeneration(GenerationProgress progress)
        {
            progress.Message = "mother fat";


            for ( var i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); i++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);//i think makes max in one
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, Main.maxTilesY);
                WorldGen.TileRunner(
                    x,
                    y,
                    (double)WorldGen.genRand.Next(3, 6),//somthing else
                    WorldGen.genRand.Next(2, 6),//somthing
                    mod.TileType("Uranium"),
                    false,
                    0f,
                    0f,
                    false,
                    true
                    );
            }
           

           
        }

        

                       
                    
    }
}
