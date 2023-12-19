using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    public class HallowedBullet : ModProjectile
    {
        private const int outerRange = 80;
        private const int innerRange = 20;
        private const int maxVelocity = 30;
        public override string Texture => "Terraria/Images/Projectiles_" + ProjectileID.ChlorophyteBullet;
        public override void SetDefaults()
        {
            Projectile.damage = 30;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 3;
        }

        public override void AI()
        {
            NPC closestNpc = null;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC currentNPC = Main.npc[i];
                if (currentNPC != null && !currentNPC.CanBeChasedBy() && Vector2.Distance(Projectile.Center, currentNPC.Center) < outerRange)
                {
                    closestNpc = currentNPC;

                }
            }
            if (closestNpc is null)
            {
                if (Projectile.velocity.Length() > maxVelocity)
                {
                    Projectile.velocity = Vector2.Normalize(Projectile.velocity) * maxVelocity;
                }
                return;
            }
            float distance = Vector2.Distance(Projectile.Center, closestNpc.Center);
            Projectile.velocity += (Projectile.Center - closestNpc.Center) * (innerRange / distance);
        }
    }
}
