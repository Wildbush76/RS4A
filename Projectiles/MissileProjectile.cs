using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    internal class MissileProjectile : ModProjectile
    {
        private Vector2 target = Vector2.Zero;
        private Stage currentStage = Stage.LAUNCH;
        private Vector2 targetPoint = Vector2.Zero;
        private int launchTimer = 30;
        

        private const float MAX_SPEED = 7;
        private const float ACCELERATION = 0.3f;
        private const int CRUISING_ALTITUDE = 2000;
        private const float ROTATION_SPEED = 0.01f;
        public enum Stage
        {
            LAUNCH,
            CLIMB,
            CRUISE,
            ATTACK
        }

        public override void OnSpawn(IEntitySource source)
        {
            target = new Vector2(Projectile.ai[0], Projectile.ai[1]);
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
                    Attack();
                    break;
            }
            FlightAnimation();
        }

        private void Launch()
        {
            Projectile.velocity.Y += MathF.CopySign(ACCELERATION, Projectile.velocity.Y);
            launchTimer--;
            if (launchTimer == 0)
            {
                if (DistanceToTarget(target)/16 > 300)
                {
                    targetPoint = new Vector2(MathF.CopySign(200, target.X - Projectile.position.X) + Projectile.position.X, CRUISING_ALTITUDE);
                    currentStage = Stage.CLIMB;
                    Main.NewText("Switching to climb");
                    Main.NewText("Climbing to X:" + targetPoint.X + " Y:" + targetPoint.Y);
                }
                else
                {
                    currentStage = Stage.ATTACK;
                    targetPoint = target;
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
            if (Projectile.position.Y <= CRUISING_ALTITUDE)
            {
                targetPoint.X = (target.X - Projectile.position.X) * (4 / 5f) + Projectile.position.X;
                Main.NewText("Crusing");
                currentStage = Stage.CRUISE;
            }
            FlyToPoint();
        }


        private void Attack() {
            FlyToPoint();
        }
        private void Cruise()
        {
            FlyToPoint();
            if (DistanceToTarget(targetPoint)/16 < 40) {
                Main.NewText("attacky");
                currentStage = Stage.ATTACK;
                targetPoint = target;
            }

        }
       

        private void FlyToPoint()
        {
            float currentAngle = MathF.Atan2(Projectile.velocity.Y, Projectile.velocity.X);
            float desiredAngle = MathF.Atan2(Projectile.position.Y - targetPoint.Y, Projectile.position.X - targetPoint.X);

            float speed = Projectile.velocity.Length();

            if (speed < MAX_SPEED)
            {
                speed += ACCELERATION;
            }

            if (Math.Abs(currentAngle - desiredAngle) < ROTATION_SPEED)
            {
                currentAngle = desiredAngle;

            }
            else if (currentAngle < desiredAngle)
            {
                if (Math.Abs(currentAngle) - Math.Abs(desiredAngle) < 180)
                {
                    currentAngle -= ROTATION_SPEED;
                }
                else
                {
                    currentAngle += ROTATION_SPEED;
                }
            }
            else
            {
                if (Math.Abs(currentAngle) - Math.Abs(desiredAngle) < 180)
                {
                    currentAngle += ROTATION_SPEED;
                }
                else
                {
                    currentAngle -= ROTATION_SPEED;
                }
            }


            Projectile.velocity.X = MathF.Cos(currentAngle) * speed;
            Projectile.velocity.Y = MathF.Sin(currentAngle) * speed;
        }

        private void FlightAnimation()
        {
            Projectile.rotation = MathF.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + MathF.PI / 2;
            Dust.NewDust(Projectile.position,5,5,DustID.Smoke);
        }

    }
}
