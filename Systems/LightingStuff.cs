using Microsoft.Xna.Framework;
using RS4A.Biomes.BlockCount;
using System;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.Events;
using Terraria.Graphics.Effects;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamityMod.Systems
{
    public class LightingStuff : ModSystem
    {
        //if this works...
        float strength = 0;
        float step = 0.02f;
        Color color = new Color(0, 255, 0);

        public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
        {
            int count = ModContent.GetInstance<BrazilBiomeTileCount>().brazilBlockCount; //need to find a more efficient way to do this lol
            if (count<=0 && strength == 0) //lmao box
            {
                return;
            }

            float desiredStrength = (float)count / 120f;
            desiredStrength = Math.Min(desiredStrength, 1f);
            //ChatHelper.SendChatMessageToClient(NetworkText.FromLiteral(desiredStrength.ToString()), Color.Green, Main.myPlayer);

            if (Math.Abs(strength-desiredStrength)<step)
            {
                strength = desiredStrength;
            } else if (strength<desiredStrength)
            {
                strength += step;
            } else if (strength>desiredStrength)
            {
                strength -= step;
            }

            int sunR = backgroundColor.R;
            int sunG = backgroundColor.G;
            int sunB = backgroundColor.B;
            // Remove some green and more red.

            backgroundColor = Color.Lerp(backgroundColor, color, strength*0.6f);
            tileColor = Color.Lerp(tileColor, color, strength * 0.5f);


        }
    }
}