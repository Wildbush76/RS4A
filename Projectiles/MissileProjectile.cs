using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    internal class MissileProjectile : ModProjectile
    {
        private Vector2 target = new(0, 500);
        private Stage currentStage = Stage.LAUNCH;
        private Vector2 targetPoint = Vector2.Zero;
        

        private const float MAX_SPEED = 20;
        private const float ACCELERATION = 0.1f;
        private const int CRUISING_ALTITUDE = 2000;
        private const float ROTATION_SPEED = 0.5f;
        public enum Stage
        {
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
            switch (currentStage)
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
            RotateByVelocity();
        }

        private void Launch()
        {
            Projectile.velocity.Y += MathF.CopySign(ACCELERATION, Projectile.velocity.Y);
            if (Math.Abs(Projectile.velocity.Y) > MAX_SPEED / 1.3)
            {
                if (DistanceToTarget(target) > 300)
                {
                    targetPoint = new Vector2(MathF.CopySign(100, target.X - Projectile.position.X) + Projectile.position.X, CRUISING_ALTITUDE);
                    currentStage = Stage.CLIMB;
                    Main.NewText("Switching to climb");
                    Main.NewText("Climbing to X:" + targetPoint.X + " Y:" + targetPoint.Y);

                }
                else
                {
                    currentStage = Stage.ATTACK;
                    Main.NewText("On the attack");
                }
            }
        }

        private double DistanceToTarget(Vector2 target)
        {
            return Vector2.Distance(Projectile.position, target);
        }

        private void Climb()
        {
            if (DistanceToTarget(targetPoint) < 20)
            {
                targetPoint.X = (target.X - Projectile.position.X) * (4 / 5f) + Projectile.position.X;
                Main.NewText("Crusing");
                currentStage = Stage.CRUISE;
            }
            FlyToPoint();
        }

        private void Cruise()
        {
            FlyToPoint();
        }

        private void FlyToPoint()
        {
            float currentAngle = MathF.Atan2(Projectile.velocity.Y, Projectile.velocity.X);
            float desiredAngle = MathF.Atan2(targetPoint.Y - Projectile.position.Y, targetPoint.X - Projectile.position.X);
            float speed = Projectile.velocity.Length();

            if (speed < MAX_SPEED)
            {
                speed += ACCELERATION;
            }

            if (Math.Abs(currentAngle - desiredAngle) < 0.3)
            {
                currentAngle = desiredAngle;

            }
            else if (currentAngle < desiredAngle)
            {
                if (Math.Abs(currentAngle - desiredAngle) < 180)
                {
                    currentAngle += ROTATION_SPEED;
                }
                else
                {
                    currentAngle -= ROTATION_SPEED;
                }
            }
            else
            {
                if (Math.Abs(currentAngle - desiredAngle) < 180)
                {
                    currentAngle -= ROTATION_SPEED;
                }
                else
                {
                    currentAngle += ROTATION_SPEED;
                }
            }


            Projectile.velocity.X = MathF.Cos(currentAngle) * speed;
            Projectile.velocity.Y = MathF.Sin(currentAngle) * speed;
        }

        private void RotateByVelocity()
        {
            Projectile.rotation = MathF.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + MathF.PI / 2;
        }

    }
}
