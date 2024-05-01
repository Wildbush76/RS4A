using Microsoft.Xna.Framework;
using RS4A.Biomes.BlockCount;
using System;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.Events;
using Terraria.Graphics.Effects;
using Terraria.Localization;
using Terraria.ModLoader;

namespace RS4A.Systems
{
    public class BrazilLighting : ModSystem
    {
        //if this works...
        float strength = 0;
        float step = 0.02f;
        Color color = new Color(0, 255, 0);

        //mfw the tmod discord tells me to do fuckin filters rather than this (i wasted so much time for nothing)

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

            //TODO chances are that theres already something to handle this buuuuuuuuuuut whatever. might make my own

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


            backgroundColor = Color.Lerp(backgroundColor, color, strength*0.3f);
            tileColor = Color.Lerp(tileColor, color, strength * 0.3f);


        }
    }
}