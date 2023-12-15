using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

//unused for now, keeping for the following logic
//TODO delete this and replace with a drawing layer

namespace RS4A.Projectiles
{
    internal class RocketLauncherTargeting : ModProjectile
    {
        private bool lockedOn = false;
        private NPC lockedOnNPC;
        private const double lockOnRadius = 48;
        private int lockOnTimer = 0;
        private const int minLockOnTime = 120;
        private const float movementSpeed = 10f;

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
            if (Main.player[Projectile.owner].HeldItem.type != ModContent.ItemType<Items.LockOnRocketLauncher>())
            {//make sure they are holding the item
                Projectile.timeLeft = 0;
            }

            Projectile.rotation += MathHelper.ToRadians(3);
            if (lockedOn)
            {
                Projectile.Center = lockedOnNPC.Center;//maybe change this to have it chase them?
            }
            else
            {
                float angle = MathF.Atan2(Main.MouseWorld.Y - Projectile.Center.Y, Main.MouseWorld.X - Projectile.Center.X);
                if (Vector2.Distance(Main.MouseWorld, Projectile.Center) <= movementSpeed)
                {
                    Projectile.Center = Main.MouseWorld;
                }
                else
                {
                    Projectile.velocity.X = movementSpeed * MathF.Cos(angle);
                    Projectile.velocity.Y = movementSpeed * MathF.Sin(angle);
                   // Projectile.Center += Projectile.velocity;
                }

                NPC closest = FindClosestNPC();
                if (closest == null)
                {
                    return;
                }
                if (Vector2.Distance(closest.Center, Projectile.Center) < lockOnRadius)
                {
                    if (lockOnTimer != minLockOnTime)
                    {
                        lockOnTimer++;
                    }
                    else
                    {
                        lockedOn = true;
                        lockedOnNPC = closest;
                    }
                }
                else
                {
                    lockOnTimer = 0;
                }
            }
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
                    float dist = Vector2.Distance(target.position, Projectile.Center);
                    if (dist < closestDist)
                    {
                        closest = target;
                        closestDist = dist;
                    }
                }
            }
            return closest;
        }

    }
}