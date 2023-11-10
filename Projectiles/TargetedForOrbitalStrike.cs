using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    internal class TargetedForOrbitalStrike : ModProjectile
    {
        private Player target;
        private bool targetLocked;
        public override void SetDefaults()
        {
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.penetrate = 1;
            Projectile.damage = 1;
            Projectile.friendly = false;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = false;
        }

        public override void OnKill(int timeLeft)
        {
            if (Projectile.owner == Main.myPlayer)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position - new Vector2(0, Main.screenHeight), new Vector2(0, 30), ModContent.ProjectileType<Projectiles.OrbitalStrikeProjectile>(), 200, 1);
            }
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (source is EntitySource_Parent parent && parent.Entity is Player player)
            {
                target = player;
            }
            base.OnSpawn(source);
        }

        public override void AI()
        {
            //TODO improve this 
            Projectile.Center = Main.player[Projectile.owner].Center;
            Projectile.rotation += MathHelper.ToRadians(6);
        }
    }
}
