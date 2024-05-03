using Microsoft.Xna.Framework;
using ReLogic.Content;
using RS4A.Projectiles;
using Terraria;
using Terraria.GameContent;
using Terraria.Map;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using RS4A.Items;

namespace RS4A.PlayerStuff
{
    internal class MissileMapLayer : ModMapLayer
    {
 
        public override void Draw(ref MapOverlayDrawContext context, ref string text)
        {
           
            foreach (Projectile projectile in Main.projectile)
            {
                if (projectile.active && projectile.type == ModContent.ProjectileType<MissileProjectile>() && projectile.owner == Main.myPlayer)
                {
                    Vector2 position = projectile.position / 16;
                    context.Draw(TextureAssets.Item[ModContent.ItemType<Missile>()].Value, position, Color.White, new SpriteFrame(1,1,0,0),0.8f,1,Alignment.Center);
                }
            }
        }
    }
}
