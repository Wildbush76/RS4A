﻿using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    internal class TargetedForOrbitalStrike : ModProjectile
    {
        private Player Target => Main.player[(int)Projectile.ai[0]];
        private bool targetLocked;
        private const float minLockOnDistance = 8;
        private float timeSpeedModifer = 0f;

        public override void SetDefaults()
        {
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.penetrate = 1;
            Projectile.damage = 1;
            Projectile.friendly = false;
            Projectile.tileCollide = false;
        }

        public override void OnKill(int timeLeft)
        {
            if (Projectile.owner == Main.myPlayer)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position - new Vector2(0, Main.screenHeight), new Vector2(0, 30), ModContent.ProjectileType<Projectiles.OrbitalStrikeProjectile>(), 200, 1);
            }
        }

        public override void AI()
        {
            if (targetLocked)
            {
                Projectile.Center = Target.Center;
            }
            else
            {
                timeSpeedModifer += 0.03f;
                float dist = Vector2.Distance(Projectile.Center, Target.Center);
                float speedModifer = dist / 60f + timeSpeedModifer;
                speedModifer = Math.Clamp(speedModifer, 1, 20);
                float angle = MathF.Atan2(Target.Center.Y - Projectile.Center.Y, Target.Center.X - Projectile.Center.X);
                Projectile.velocity.X = speedModifer * MathF.Cos(angle);
                Projectile.velocity.Y = speedModifer * MathF.Sin(angle);
                Projectile.position += Projectile.velocity;//maybe?

                if (dist <= minLockOnDistance)
                {
                    Projectile.timeLeft = 200;
                    targetLocked = true;
                }
            }
            //TODO improve this 

            Projectile.rotation += MathHelper.ToRadians(6);
        }
    }
}
