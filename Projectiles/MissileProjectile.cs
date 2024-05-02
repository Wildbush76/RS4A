using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{ 
    internal class MissileProjectile : ModProjectile
    {
        private static readonly Random random = new();
        private Vector2 target = Vector2.Zero;
        private Stage currentStage = Stage.LAUNCH;
        private Vector2 targetPoint = Vector2.Zero;
        private int launchTimer = 30;
        private int delay;


        private const int MAX_LAUNCH_DELAY = 180;
        private const float MAX_SPEED = 30;
        private const float ACCELERATION = 0.3f;
        private const int CRUISING_ALTITUDE = 1000;
        private const float ROTATION_SPEED = 0.02f;
        private const int TILE_COLLIDE_RANGE = 40;//range to players or target to enable tile collide
        private const int INACCURACY = 20;//Plus or minus this value on X
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
            delay = random.Next(60, MAX_LAUNCH_DELAY);
            target = new Vector2(Projectile.ai[0] + random.Next(-INACCURACY, INACCURACY) * 16, Projectile.ai[1]);
        }
        public override void SetDefaults()
        {
            Projectile.damage = 300;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 14;
            Projectile.height = 35;
            Projectile.penetrate = 1;
            Projectile.tileCollide = false;
            Projectile.Opacity = 0;
        }

        public void CheckTileCollide()
        {
            if (DistanceToTarget(target) / 16 < TILE_COLLIDE_RANGE)
            {
                Projectile.tileCollide = true;
            }
            else
            {
                foreach (Player player in Main.player)
                {
                    if (DistanceToTarget(player.position) / 16 < TILE_COLLIDE_RANGE)
                    {
                        Projectile.tileCollide = true;
                        return;
                    }
                }
                Projectile.tileCollide = false;
            }

        }

        public override bool PreAI()
        {
            if (delay != 0)
            {

                if (--delay == 0)
                {
                    Projectile.Opacity = 1;
                }
                else if (delay < 60)
                {
                    Dust.NewDust(Projectile.BottomLeft, Projectile.width, 5, ModContent.DustType<Dusts.SmokeCloud>(),SpeedX: random.NextSingle() * 50 - 25, SpeedY: random.NextSingle() * 2 - 1);
                }
                return false;
            }
            return true;
        }

        public override void AI()
        {
            
                switch (currentStage)
                {
                    case Stage.LAUNCH:
                        Launch();
                        break;
                    case Stage.NONTARGETING:
                        CheckTileCollide();
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
            // Play explosion sound
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            // Smoke Dust spawn
            for (int i = 0; i < 50; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 2f);
                dust.velocity *= 1.4f;
            }

            // Fire Dust spawn
            for (int i = 0; i < 80; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 3f);
                dust.noGravity = true;
                dust.velocity *= 5f;
                dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 2f);
                dust.velocity *= 3f;
            }

            // Large Smoke Gore spawn
            for (int g = 0; g < 2; g++)
            {
                var goreSpawnPosition = new Vector2(Projectile.position.X + Projectile.width / 2 - 24f, Projectile.position.Y + Projectile.height / 2 - 24f);
                Gore gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                gore.scale = 1.5f;
                gore.velocity.X += 1.5f;
                gore.velocity.Y += 1.5f;
                gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                gore.scale = 1.5f;
                gore.velocity.X -= 1.5f;
                gore.velocity.Y += 1.5f;
                gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                gore.scale = 1.5f;
                gore.velocity.X += 1.5f;
                gore.velocity.Y -= 1.5f;
                gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                gore.scale = 1.5f;
                gore.velocity.X -= 1.5f;
                gore.velocity.Y -= 1.5f;
            }

            if (Projectile.owner == Main.myPlayer)
            {
                int explosionRadius = 7;
                int minTileX = (int)(Projectile.Center.X / 16f - explosionRadius);
                int maxTileX = (int)(Projectile.Center.X / 16f + explosionRadius);
                int minTileY = (int)(Projectile.Center.Y / 16f - explosionRadius);
                int maxTileY = (int)(Projectile.Center.Y / 16f + explosionRadius);

                // Ensure that all tile coordinates are within the world bounds
                Utils.ClampWithinWorld(ref minTileX, ref minTileY, ref maxTileX, ref maxTileY);

                // These 2 methods handle actually mining the tiles and walls while honoring tile explosion conditions
                bool explodeWalls = Projectile.ShouldWallExplode(Projectile.Center, explosionRadius, minTileX, maxTileX, minTileY, maxTileY);
                Projectile.ExplodeTiles(Projectile.Center, explosionRadius, minTileX, maxTileX, minTileY, maxTileY, explodeWalls);
                Main.player[Main.myPlayer].Hurt(PlayerDeathReason.ByCustomReason(Main.player[Main.myPlayer].name + " was a dumbass"), 2000, 1, dodgeable: false);
            }
        }
        private void SetNextTargetPoint()
        {
            switch (currentStage)
            {
                case Stage.CLIMB:
                    targetPoint.X = (target.X - Projectile.position.X) * (4 / 5f) + Projectile.position.X;
                    Main.NewText("Cruise");
                    currentStage = Stage.CRUISE;
                    break;
                case Stage.CRUISE:
                    Main.NewText("attack");
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
                    targetPoint = new Vector2(MathF.CopySign(200, target.X - Projectile.position.X) + Projectile.position.X, target.Y - CRUISING_ALTITUDE);
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



        private bool FlyToPoint()
        {
            float speed = Projectile.velocity.Length();

            if (speed < MAX_SPEED)
            {
                speed += ACCELERATION;
            }
         

            Projectile.velocity = Vector2.Lerp( Vector2.Normalize(Projectile.velocity),Vector2.Normalize(targetPoint-Projectile.position),0.05f) * speed;
           
            return DistanceToTarget(targetPoint) / 16 < 5;
            
        }

        private void FlightAnimation()
        {
            Projectile.rotation = MathF.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + MathF.PI / 2;
            Vector2 location = Projectile.Center - Vector2.Normalize(Projectile.velocity) * (Projectile.height / 2);

            //Gore.NewGore(Projectile.GetSource_FromThis(), location,-Projectile.velocity, GoreID.Smoke1);
            Dust.NewDustPerfect(location,  DustID.Torch);
            //Dust.NewDust(location, Projectile.width, 5, ModContent.DustType<Dusts.SmokeCloud>());
            Dust.NewDustPerfect(location,ModContent.DustType<Dusts.SmokeCloud>());
        }

    }
}
