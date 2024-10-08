﻿using Microsoft.Xna.Framework;
using ReLogic.Utilities;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    internal class MissileProjectile : ModProjectile
    {
        private static readonly Random random = new();
        private Vector2 target = Vector2.Zero;
        private Stage currentStage = Stage.LAUNCH;
        private Vector2 targetPoint = Vector2.Zero;
        private SlotId soundSlot;

        private int launchTimer = 30;

        private const float MAX_SPEED = 30;
        private const float ACCELERATION = 0.3f;
        private const int CRUISING_ALTITUDE = 1000;
        private const int TILE_COLLIDE_RANGE = 40;//range to players or target to enable tile collide
        private const int INACCURACY = 20;//Plus or minus this value on X
        private readonly Vector3 FLAME_COLOR = new(2, 0.7f, 0.3f);
        public enum Stage
        {
            LAUNCH,
            CLIMB,
            CRUISE,
            ATTACK,
            NONTARGETING
        }

        public override void OnSpawn(IEntitySource source)
        {
            SoundEngine.PlaySound(new SoundStyle($"{nameof(RS4A)}/Sounds/launch")
            {
                IsLooped = false,
                Volume = 0.1f
            }) ;
            soundSlot = SoundEngine.PlaySound(new SoundStyle($"{nameof(RS4A)}/Sounds/looplaunch")//TODO set this to be the right one
            {
                IsLooped = true,
                Volume = 0.5f,
                PitchVariance = 0.2f,
                MaxInstances = 1,
            });

            target = new Vector2(Projectile.ai[0] + random.Next(-INACCURACY, INACCURACY) * 16, Projectile.ai[1] + random.Next(-INACCURACY, INACCURACY) * 8);

            for (int i = 0; i < 30; i++) {
                Dust.NewDust(Projectile.BottomLeft, Projectile.width, 5, ModContent.DustType<Dusts.SmokeCloud>(), SpeedX: random.NextSingle() - 0.5f, SpeedY: random.NextSingle() / 5f);
            }
        }
    


        public Vector2 GetTarget()
        {
            return target;
        }

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            Projectile.damage = 300;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.width = 14;
            Projectile.height = 35;
            Projectile.penetrate = 1;
            SetCollide(false);
        }

        private void SetCollide(bool collide)
        {
            Projectile.tileCollide = collide;
            Projectile.friendly = collide;
            Projectile.hostile = collide;
        }

        public void CheckTileCollide()
        {
            if (DistanceToTarget(target) / 16 < TILE_COLLIDE_RANGE)
            {
                SetCollide(true);
            }
            else
            {
                foreach (Player player in Main.player)
                {
                    if (DistanceToTarget(player.position) / 16 < TILE_COLLIDE_RANGE)
                    {
                        SetCollide(true);
                        return;
                    }
                }
                SetCollide(false);
            }

        }

      

        public override void AI()
        {

            switch (currentStage)
            {
                case Stage.LAUNCH:
                    Launch();
                    break;
                case Stage.NONTARGETING:
                    Projectile.tileCollide = true;
                    break;
                default:
                    if (FlyToPoint())
                    {
                        SetNextTargetPoint();
                    }
                    CheckTileCollide();
                    break;

            }


            FlightAnimation();
        }


        public override void OnKill(int timeLeft)
        {

            if (SoundEngine.TryGetActiveSound(soundSlot, out ActiveSound sound)) {
                sound.Stop();
                
            }
            RS4AUtils.Explode.Explosion(Projectile, 10, Projectile.damage, true, [" got turned into ash", " was rapidly disassembled", " was blown to bits"]);
        }
        private void SetNextTargetPoint()
        {
            switch (currentStage)
            {
                case Stage.CLIMB:
                    targetPoint.X = (target.X - Projectile.position.X) * (8 / 9f) + Projectile.position.X;
                    targetPoint.Y += random.Next(-50, 50);
                    currentStage = Stage.CRUISE;
                    break;
                case Stage.CRUISE:
                    currentStage = Stage.ATTACK;
                    targetPoint = target;
                    break;
                case Stage.ATTACK:
                    currentStage = Stage.NONTARGETING;
                    break;
            }
        }

        private void Launch()
        {
            Projectile.velocity.Y -= ACCELERATION;
            launchTimer--;
            if (launchTimer == 0)
            {
                if (DistanceToTarget(target) / 16 > 300)
                {
                    float targetHeight = Math.Min(target.Y, Projectile.Center.Y) - CRUISING_ALTITUDE;
                    targetHeight = Math.Max(targetHeight, Main.topWorld - 20);
                    targetPoint = new Vector2(MathF.CopySign(400, target.X - Projectile.position.X) + Projectile.position.X, targetHeight);
                    currentStage = Stage.CLIMB;
                }
                else
                {
                    currentStage = Stage.ATTACK;
                    targetPoint = target;
                }
            }
        }

        private double DistanceToTarget(Vector2 target)
        {
            return Vector2.Distance(Projectile.position, target);
        }



        private bool FlyToPoint()
        {
            float speed = Projectile.velocity.Length();

            if (speed < MAX_SPEED)
            {
                speed += ACCELERATION;
            }


            Projectile.velocity = Vector2.Lerp(Vector2.Normalize(Projectile.velocity), Vector2.Normalize(targetPoint - Projectile.position), 0.05f) * speed;
            return DistanceToTarget(targetPoint) / 16 < 10;

        }

        private void FlightAnimation()
        {
            if (SoundEngine.TryGetActiveSound(soundSlot, out ActiveSound sound)) {
                sound.Position = Projectile.Center;
            }
            if (++Projectile.frameCounter >= 3)
            {
                Projectile.frameCounter = 0;
                Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
            }


            Projectile.rotation = Projectile.velocity.ToRotation() + MathF.PI / 2;
            Vector2 location = Projectile.Center - Vector2.Normalize(Projectile.velocity) * (Projectile.height / 2);
            Lighting.AddLight(location, FLAME_COLOR);
            Dust dust = Dust.NewDustPerfect(location, DustID.Torch);
            dust.noGravity = true;
            Dust.NewDustPerfect(location, ModContent.DustType<Dusts.SmokeCloud>(), Vector2.Zero, Scale: 1.2f);
        }

    }
}
