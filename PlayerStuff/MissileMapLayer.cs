﻿using Microsoft.Xna.Framework;
using RS4A.Items;
using RS4A.Projectiles;
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
                    context.Draw(TextureAssets.Item[ModContent.ItemType<Missile>()].Value, position, Color.White, new SpriteFrame(1, 1, 0, 0), 0.8f, 1, Alignment.Center);
                    context.Draw(TextureAssets.Projectile[ModContent.ProjectileType<TargetedForOrbitalStrike>()].Value, missileProjectile.GetTarget() / 16, Color.Crimson, new SpriteFrame(1, 1, 0, 0), 0.3f, 0.8f, Alignment.Center);
                }
            }
        }
    }
}
