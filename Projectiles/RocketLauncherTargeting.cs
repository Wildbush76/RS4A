using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    internal class RocketLauncherTargeting : ModProjectile
    {
        private readonly bool lockedOn;
        private NPC lockedOnNPC;
        private const double lockOnRadius = 5 * 8;

        public override void SetDefaults()
        {
            Projectile.tileCollide = false;

        }

        public override void AI()
        {
            if (Main.player[Projectile.owner].HeldItem.type == ModContent.ItemType<Items.LockOnRocketLauncher>()) {
                Projectile.timeLeft = 0;
            }
            if (lockedOn)
            {
               
            }
            else
            {
                Projectile.position = Main.MouseWorld;

            }
        }

        private NPC findClosestNPC()
        {
            NPC closest = null;
            float closestDist = float.MaxValue;
            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];
                if (target.CanBeChasedBy())
                {
                    float dist = Vector2.Distance(target.position,Projectile.position);
                    if (dist < closestDist) {
                        closest = target;
                        closestDist = dist;
                    }
                }
            }
            return closest;
        }

    }
}