using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace RS4A.Systems
{
    public class NuclearFlash : ModSystem
    {

        public static void TriggerFlash()
        {
            FlashTimer = MaxFlashTime;
        }
        private static int FlashTimer;
        private static int MaxFlashTime = 60;

        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            if (FlashTimer > 0)
            {

                float opacity = (float)FlashTimer / MaxFlashTime;
                spriteBatch.Draw(
                    TextureAssets.MagicPixel.Value,
                    new Rectangle(0, 0, Main.screenWidth, Main.screenHeight),
                    Color.White * opacity
                );

                FlashTimer--;
            }
        }
    }
}
