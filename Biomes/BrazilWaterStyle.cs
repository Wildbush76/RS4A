using RS4A.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace RS4A.Biomes
{
    public class BrazilWaterStyle : ModWaterStyle
    {
        public override int ChooseWaterfallStyle()
        {
            return ModContent.GetInstance<BrazilWaterfallStyle>().Slot;
        }

        public override int GetSplashDust()
        {
            return ModContent.DustType<BrazilWater>();
        }

        public override int GetDropletGore()
        {
            return ModContent.Find<ModGore>("RS4A/NPCs/StupidBoss/MinionBossBody_Back").Type; //why the fuck do you need this? doesnt even fuckin work lol
        }

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = 1f;
            b = 0f;
        }

        public override Color BiomeHairColor()
        {
            return Color.LimeGreen;
        }

        public override byte GetRainVariant()
        {
            return (byte)Main.rand.Next(3);
        }

        public override Asset<Texture2D> GetRainTexture()
        {
            return ModContent.Request<Texture2D>("RS4A/Biomes/BrazilRain");
        }
    }
}