using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    internal class RocketLauncherTargeting : ModProjectile
    {
        private bool lockedOn = false;
        private NPC lockedOnNPC;
        private const double lockOnRadius = 5 * 8;

        public override void SetDefaults()
        {
            Projectile.tileCollide = false;
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.damage = 0;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override void AI()
        {
            if (Main.player[Projectile.owner].HeldItem.type != ModContent.ItemType<Items.LockOnRocketLauncher>()) {
                Projectile.timeLeft = 0;
            }
            if (lockedOn)
            {
                Projectile.Center = lockedOnNPC.Center;
            }
            else
            {
                Projectile.Center = Main.MouseWorld;
                NPC closest = FindClosestNPC();
                if (closest == null) {
                    return;
                }
                if (Vector2.Distance(closest.Center, Projectile.Center) < lockOnRadius) {
                    lockedOn = true;
                    lockedOnNPC = closest;
                }
            }
            Projectile.rotation= MathHelper.ToRadians(6);
        }

        private NPC FindClosestNPC()
        {
            NPC closest = null;
            float closestDist = float.MaxValue;
            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];
                if (target.CanBeChasedBy())
                {
                    float dist = Vector2.Distance(target.position,Projectile.Center);
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