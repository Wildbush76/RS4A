using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RS4A.Items;
using RS4A.Projectiles;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Map;
using Terraria.ModLoader;
using Terraria.UI;

namespace RS4A.PlayerStuff
{
    internal class MissileMapLayer : ModMapLayer
    {

        public override void Draw(ref MapOverlayDrawContext context, ref string text)
        {
            foreach (Projectile projectile in Main.projectile)
            {
                if (projectile.active && projectile.ModProjectile is MissileProjectile missileProjectile && projectile.owner == Main.myPlayer)//TODO package this in a helper function, could be useful later
                {
                    Vector2 position = projectile.position / 16;
              
                    position = (position - context.MapPosition) * context.MapScale + context.MapOffset;

                    if (!context.ClippingRectangle.HasValue || context.ClippingRectangle.Value.Contains(position.ToPoint()))
                    {
                        float rotation = MathF.Atan2(projectile.velocity.Y, projectile.velocity.X) + MathHelper.ToRadians(90);
                        Texture2D texture = TextureAssets.Item[ModContent.ItemType<Missile>()].Value;
                        SpriteFrame frame = new SpriteFrame(1, 1, 0, 0);

                        Rectangle sourceRectangle = frame.GetSourceRectangle(texture);
                        Vector2 vector = sourceRectangle.Size() * Alignment.Center.OffsetMultiplier;
                        Vector2 position2 = position;
                        
                        float scale = context.DrawScale;
                

                        Main.spriteBatch.Draw(texture, position2, sourceRectangle, Color.White, rotation, vector, scale, SpriteEffects.None, 0f);
                    }


                    context.Draw(TextureAssets.Projectile[ModContent.ProjectileType<TargetedForOrbitalStrike>()].Value, missileProjectile.GetTarget() / 16, Color.Crimson, new SpriteFrame(1, 1, 0, 0), 0.3f, 0.8f, Alignment.Center);
                }
            }
        }
    }
}
