using Terraria.ModLoader;

namespace RS4A.Biomes //not sure why it was backgrounds for example mod lol
{
    public class BrazilSurfaceBackgroundStyle : ModSurfaceBackgroundStyle
    {
        // Use this to keep far Backgrounds like the mountains.
        public override void ModifyFarFades(float[] fades, float transitionSpeed)
        {
            for (int i = 0; i < fades.Length; i++)
            {
                if (i == Slot)
                {
                    fades[i] += transitionSpeed;
                    if (fades[i] > 1f)
                    {
                        fades[i] = 1f;
                    }
                }
                else
                {
                    fades[i] -= transitionSpeed;
                    if (fades[i] < 0f)
                    {
                        fades[i] = 0f;
                    }
                }
            }
        }

        public override int ChooseFarTexture()
        {
            return BackgroundTextureLoader.GetBackgroundSlot("RS4A/Biomes/Backgrounds/ExampleBiomeSurfaceFar"); // You can use the full path version of GetBackgroundSlot too
        }

        public override int ChooseMiddleTexture()
        {
            return BackgroundTextureLoader.GetBackgroundSlot("RS4A/Biomes/Backgrounds/ExampleBiomeSurfaceMid"); // You can use the full path version of GetBackgroundSlot too
        }

        public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
        {
            return BackgroundTextureLoader.GetBackgroundSlot("RS4A/Biomes/Backgrounds/ExampleBiomeSurfaceClose"); // You can use the full path version of GetBackgroundSlot too
        }
    }
}