using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    internal class Targeting : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = 11;
            Projectile.width = 22;
            Projectile.height = 22;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            //something
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
    }
}
