using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using ReLogic.Content;
using Terraria;
using RS4A.Skies;

namespace RS4A
{
    public class RS4A : Mod
	{
        public static Texture2D VoidSky;
        //god, lookin at old code is making me vomit, especially with the indentation (which has *mostly* been fixed. do Ctrl+K, Ctrl+D to fix btw)
        public override void Load()
        {
            // All of this loading needs to be client-side.

            if (Main.netMode != NetmodeID.Server)
            {
                VoidSky = ModContent.Request<Texture2D>("RS4A/Skies/Void", AssetRequestMode.ImmediateLoad).Value;
                // First, you load in your shader file.
                // You'll have to do this regardless of what kind of shader it is,
                // and you'll have to do it for every shader file.
                // This example assumes you have both armor and screen shaders.
                Ref<Effect> filterRef = new Ref<Effect>(this.Assets.Request<Effect>("Effects/Filters/Radiation", AssetRequestMode.ImmediateLoad).Value);
                Filters.Scene["Radiation"] = new Filter(new ScreenShaderData(filterRef, "Radiation"), EffectPriority.High);
                SkyManager.Instance["Brazil"] = new VoidSky();
            }
        }





    }
}