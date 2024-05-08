using Microsoft.Xna.Framework;
using rail;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    internal class PotionOfExplodingProjectile : ModProjectile
    {
       
        public override void SetDefaults()
        {
            Projectile.timeLeft = 0;
        }

        public override void OnKill(int timeLeft)
        {
            Player player = Main.player[Main.myPlayer];
            RS4AUtils.Explode.Explosion(Projectile, 5, 5000, false, [" was a moron", " earned a Darwin award", " was a dumbass", " wanted to explode"]);
        }
    }

}
