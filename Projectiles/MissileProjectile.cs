using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Biomes;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    internal class MissileProjectile : ModProjectile
    {
        private Vector2 target = new Vector2(0,500);
        private Stage currentStage = Stage.LAUNCH;
        private Vector2 targetPoint = Vector2.Zero;
        private Vector2 desiredVelocity = Vector2.Zero;
       


        private const float MAX_SPEED = 20;
        private const float ACCELERATION = 0.1f;
        private const int CRUISING_ALTITUDE = 2000;
        public enum Stage {
            LAUNCH,
            CLIMB,
            CRUISE,
            ATTACK
        }
        public override void SetDefaults()
        {
            Projectile.damage = 300;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 23;
            Projectile.height = 36;
            Projectile.penetrate = 1;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            switch(currentStage)
            {
                case Stage.LAUNCH:
                    Launch();
                    break;
                case Stage.CLIMB:
                    Climb();
                    break;
                case Stage.CRUISE:
                    Cruise();
                    break; 
                case Stage.ATTACK:
                    break;
            }
        }

        private void Launch() {
            Projectile.velocity.Y /= 1.4f;
            if (Math.Abs(Projectile.velocity.Y) < 2) {
                if (DistanceToTarget(target) > 200)
                {
                    targetPoint = new Vector2((target.X - Projectile.position.X) / 5 + Projectile.position.X, CRUISING_ALTITUDE);
                    currentStage = Stage.CLIMB;
                    Main.NewText("Switching to climb");
                    Main.NewText("Climbing to " + targetPoint.X);
                }
                else
                {
                    currentStage = Stage.ATTACK;
                    Main.NewText("On the attack");
                }
            }
        }

        private double DistanceToTarget(Vector2 target) { 
            return Vector2.Distance(Projectile.position, target);
        }

        private void Climb() {
            if (DistanceToTarget(targetPoint) < 20) {
                targetPoint.X = (target.X - Projectile.position.X) * (4/5f) + Projectile.position.X;
                Main.NewText("Crusing");
                currentStage = Stage.CRUISE;
            }
            FlyToPoint();
        }

        private void Cruise() {
            FlyToPoint();
        }

        private void FlyToPoint() {
            desiredVelocity = targetPoint - Projectile.position;
            desiredVelocity.Normalize();
            desiredVelocity *= MAX_SPEED;

            Projectile.velocity = Vector2.Lerp(Projectile.velocity, desiredVelocity, ACCELERATION);
        }

    }
}
