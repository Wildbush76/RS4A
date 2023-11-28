using Terraria.ModLoader;

namespace RS4A.Biomes
{
    public class BrazilUndergroundBackgroundStyle : ModUndergroundBackgroundStyle
    {
        public override void FillTextureArray(int[] textureSlots)
        {
            textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot("RS4A/Biomes/Backgrounds/ExampleBiomeUnderground0");
            textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot("RS4A/Biomes/Backgrounds/ExampleBiomeUnderground1");
            textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot("RS4A/Biomes/Backgrounds/ExampleBiomeUnderground2");
            textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot("RS4A/Biomes/Backgrounds/ExampleBiomeUnderground3");
        }
    }
}