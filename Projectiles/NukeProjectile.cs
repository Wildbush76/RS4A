using Microsoft.Xna.Framework;
using RS4A.Tiles;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Projectiles
{
    public class NukeProjectile : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.damage = 100;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 23;
            Projectile.height = 36;
            Projectile.aiStyle = 1;
            Projectile.penetrate = 1;
        }
        public override void OnKill(int timeLeft)
        {
            RS4AUtils.Explode.Explosion(Projectile, 6, Projectile.damage, false, [" split the atom", " wanted to be nuclear ash"]);
        }
    }
}
