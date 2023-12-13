using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RS4A.Biomes.BlockCount;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace RS4A.Skies
{
    public class BrazilSky : CustomSky
    {
        //OK so basically i found a better way to do this lol

        //this still has a use, but will be unused for now
        private bool skyActive;
        public float intensity = 0f;
        private float intensityDesired = 0f;
        private float fadeAmnt = 0.02f; //how fast it fades in and out of the amount
        private const float ScreenParralaxMultiplier = 0.4f;

        // Vanila scales backgrounds to 250% size. Depending on what you might want to do you can change this if you wanted to make a non scaled bg.
        private const float Scale = 2.5f;

        public override void Deactivate(params object[] args)
        {
            skyActive = GetBlocks() >= 40;
            intensity = 0f;
            intensityDesired = 0f;
        }

        public override void Reset()
        {
            skyActive = false;
            intensity = 0f;
            intensityDesired = 0f;
    }
        private int GetBlocks()
        {
            return ModContent.GetInstance<BrazilBiomeTileCount>().brazilBlockCount;

        }
        public override bool IsActive()
        {
            return skyActive;
        }
        public override Color OnTileColor(Color inColor)
        {
            return new Color(Vector4.Lerp(new Vector4(0.2f, 1.0f, 0.2f, 1f), inColor.ToVector4(), 1f - intensity));
        }
        public override void Activate(Vector2 position, params object[] args)
        {
            skyActive = true;
        }

        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            if (maxDepth >= 100f && minDepth < 100f)
            {
                spriteBatch.Draw(RS4A.BrazilSky, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Lerp(Main.ColorOfTheSkies, Color.LightSeaGreen, 0.33f) * intensity); //I'll probably get a better background than void but for right now this works surprisingly well!
            }
        }

        public override void Update(GameTime gameTime)
        {
            //shit code written by yours truly
            int blocksAround = GetBlocks();
            intensityDesired = ((float)blocksAround - 40.0f)/40.0f; //if 80 blocks around, go nuts balls, start doing effect at 40 blocks
            if (intensityDesired>1f)
            {
                intensityDesired = 1f;
            }
            if (intensityDesired < 0f)
            {
                intensityDesired = 0f;
            }
            
            if (Math.Abs(intensityDesired-intensity)<fadeAmnt)
            {
                intensity = intensityDesired;
            } else
            {
                if (intensity<intensityDesired)
                {
                    intensity += fadeAmnt;
                } else
                {
                    intensity -= fadeAmnt;
                }
            }
            if (Main.gameMenu)
            {
                skyActive = false;
            }
        }
    }
}