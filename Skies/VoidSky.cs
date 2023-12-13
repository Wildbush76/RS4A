using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RS4A.Biomes.BlockCount;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Skies
{
    public class VoidSky : CustomSky
    {
        private bool skyActive;
        private float opacity = 0f;

        private const float ScreenParralaxMultiplier = 0.4f;

        // Vanila scales backgrounds to 250% size. Depending on what you might want to do you can change this if you wanted to make a non scaled bg.
        private const float Scale = 2.5f;

        public override void Deactivate(params object[] args)
        {
            skyActive = ModContent.GetInstance<BrazilBiomeTileCount>().brazilBlockCount >= 40;
        }

        public override void Reset()
        {
            skyActive = false;
        }
        private float GetIntensity()
        {
            return 1f - Utils.SmoothStep(3000f, 6000f, 200f);
        }
        public override bool IsActive()
        {
            return skyActive;
        }
        public override Color OnTileColor(Color inColor)
        {
            float intensity = GetIntensity();
            return new Color(Vector4.Lerp(new Vector4(0.2f, 1.0f, 0.2f, 1f), inColor.ToVector4(), 1f - intensity)); //YOU MEAN TO FUCKING TELL ME THAT I COULD'VE SKIPPED DOING *ALL* OF THAT FUCKING WORK FIGURING OUT FILTERS AND JUST STUCK TO THIS??????????????????????????? FUCK DUDE. mfw the tmod discord ends up sending me back in progress by a fucking mile. 
        }
        public override void Activate(Vector2 position, params object[] args)
        {
            skyActive = true;
        }

        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            if (maxDepth >= 0f && minDepth < 0f)
            {
                float intensity = GetIntensity();
                spriteBatch.Draw(RS4A.VoidSky, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Black * intensity); //I'll probably get a better background than void but for right now this works surprisingly well!
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (Main.gameMenu)
            {
                skyActive = false;
            }
        }
    }
}