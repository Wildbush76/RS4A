using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    public class HallowedBullet : ModProjectile
    {
        private const int outerRange = 80;
        private const int innerRange = 20;
        private const int maxVelocity = 60;
        private const int maxNormalVelocity = 30;
        public override string Texture => "Terraria/Images/Item_" + ItemID.ChlorophyteBullet;
        public override void SetDefaults()
        {
            Projectile.damage = 30;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 3;
        }


        private float GetDistance(Vector2 posOne, int width, int height, Vector2 posTwo) { 
            float maxOffset = Math.Max(width, height);
            return Vector2.Distance(posOne,posTwo) + maxOffset;
        }
        

        public override void AI()
        {
            NPC closestNpc = null;
            float dist = 0;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC currentNPC = Main.npc[i];
                float tempDist = GetDistance(currentNPC.Center, currentNPC.width, currentNPC.height, Projectile.Center);
                if (currentNPC != null && !currentNPC.CanBeChasedBy() && tempDist < outerRange)
                {
                    closestNpc = currentNPC;
                    dist = tempDist;
                }
            }
            if (closestNpc is null)
            {
                if (Projectile.velocity.Length() > maxNormalVelocity) { 
                    Projectile.velocity = Vector2.Normalize(Projectile.velocity) * maxNormalVelocity;
                }
                return;
            }
            Vector2 target = Vector2.Normalize(Projectile.Center - closestNpc.Center) * (maxVelocity * (innerRange/dist));

            Projectile.velocity = Vector2.Lerp(Projectile.velocity,target,innerRange/dist);
        }
    }
}
