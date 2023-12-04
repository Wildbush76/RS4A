using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace RS4A
{
	public class RS4A : Mod
	{
        //god, lookin at old code is making me vomit, especially with the indentation (which has *mostly* been fixed. do Ctrl+K, Ctrl+D to fix btw)


        public override void Load()
        {

            // All of this loading needs to be client-side.

            if (Main.netMode != NetmodeID.Server)
            {
                // First, you load in your shader file.
                // You'll have to do this regardless of what kind of shader it is,
                // and you'll have to do it for every shader file.
                // This example assumes you have both armor and screen shaders.
                
                Ref<Effect> filterRef = new Ref<Effect>(this.Assets.Request<Effect>("Effects", AssetRequestMode.ImmediateLoad).Value);

                // To bind a screen shader, use this.
                // EffectPriority should be set to whatever you think is reasonable.   

                Filters.Scene["FilterName"] = new Filter(new ScreenShaderData(filterRef, "PassName"), EffectPriority.High);
            }
        }





    }
}