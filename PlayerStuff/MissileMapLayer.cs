using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RS4A.Items;
using RS4A.Projectiles;
using RS4A.RS4AUtils;
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
                if (projectile.active && projectile.ModProjectile is MissileProjectile missileProjectile && projectile.owner == Main.myPlayer)
                {
                    Vector2 position = projectile.position / 16;
                    float rotation = MathF.Atan2(projectile.velocity.Y, projectile.velocity.X) + MathHelper.ToRadians(90);

                    Maputils.DrawOnMapWithRotation(ref context, TextureAssets.Item[ModContent.ItemType<Missile>()].Value, position, Color.White, rotation, new SpriteFrame(1, 1, 0, 0), 1, 1, Alignment.Center, SpriteEffects.None);
                    context.Draw(TextureAssets.Projectile[ModContent.ProjectileType<TargetedForOrbitalStrike>()].Value, missileProjectile.GetTarget() / 16, Color.Crimson, new SpriteFrame(1, 1, 0, 0), 0.3f, 0.8f, Alignment.Center);
                }
            }
        }
    }
}
