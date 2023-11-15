using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace RS4A.Generation
{
    public class WorldGenModifications : ModSystem
    {
        //being honest, this class ain doin much

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies")); //vanilla do be callin en shinies

            if (ShiniesIndex != -1)
            {
                // Next, we insert our pass directly after the original "Shinies" pass.
                // ExampleOrePass is a class seen bellow
                tasks.Insert(ShiniesIndex + 1, new UraniumGeneration("Uranium", 237.4298f));
            }
        }
    }
}