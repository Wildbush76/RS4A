using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Map;
using Terraria.UI;

namespace RS4A.RS4AUtils
{
	internal class Maputils
	{
		
		public static MapOverlayDrawContext.DrawResult DrawOnMapWithRotation(ref MapOverlayDrawContext context, Texture2D texture, Vector2 position, Color color, float rotation, SpriteFrame frame, float scaleIfNotSelected, float scaleIfSelected, Alignment alignment, SpriteEffects spriteEffects) {
			position = (position - context.MapPosition) * context.MapScale + context.MapOffset;
			if (context.ClippingRectangle.HasValue && !context.ClippingRectangle.Value.Contains(position.ToPoint()))
				return  MapOverlayDrawContext.DrawResult.Culled;

			Rectangle sourceRectangle = frame.GetSourceRectangle(texture);
			Vector2 vector = sourceRectangle.Size() * alignment.OffsetMultiplier;
			Vector2 position2 = position;
			float num = context.DrawScale * scaleIfNotSelected;
			Vector2 vector2 = position - vector * num;
			bool num2 = new Rectangle((int)vector2.X, (int)vector2.Y, (int)((float)sourceRectangle.Width * num), (int)((float)sourceRectangle.Height * num)).Contains(Main.MouseScreen.ToPoint());
			float scale = num;
			if (num2)
				scale = context.DrawScale * scaleIfSelected;

			Main.spriteBatch.Draw(texture, position2, sourceRectangle, color, rotation, vector, scale, spriteEffects, 0f);
			return new MapOverlayDrawContext.DrawResult(num2);
		}

		
	}
}