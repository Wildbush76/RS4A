using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Utilities;
using RS4A.Items;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    public class FirstPrismHoldout : ModProjectile
    {
        public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.LastPrism;
        private const float AimResponsiveness = 0.08f;
        public const float MaxCharge = 180f;
        private const int NumAnimationFrames = 5;
        private const int MaxShootDelay = 50;
        private const int MinShootDelay = 10;
        private const int DefaultSpeed = 15;

        private SlotId slot;

        private float FrameCounter
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = NumAnimationFrames;
            ProjectileID.Sets.HeldProjDoesNotUsePlayerGfxOffY[Type] = true;
        }
        public override void OnSpawn(IEntitySource source)
        {
            slot = SoundEngine.PlaySound(new SoundStyle($"{nameof(RS4A)}/Sounds/FirstPrismHumm")
            {
                IsLooped = true,
                Volume = 0.2f,
                PitchVariance = 0.4f,
                MaxInstances = 1
            });
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.TryGetActiveSound(slot, out ActiveSound sound);

            sound?.Stop();

        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Vector2 rrp = player.RotatedRelativePoint(player.MountedCenter, true);
            FrameCounter += 1f;
            UpdateAnimation();
            UpdatePlayerVisuals(player, rrp);
            UpdateAim(rrp, player.HeldItem.shootSpeed);
            ShootProjectile();
            if (!player.channel)
            {
                Projectile.Kill();
            }
            Projectile.timeLeft = 2;
            Lighting.AddLight(Projectile.position, new Vector3(0.831f, 0.824f, 0.361f));
        }

        private void ShootProjectile()
        {
            int delay;
            if (FrameCounter < MaxCharge)
            {
                delay = (int)(FrameCounter / 180 * (MinShootDelay - MaxShootDelay) + MaxShootDelay);
            }
            else
            {
                delay = MinShootDelay;
            }
            if (FrameCounter % delay == 0)
            {
                Random rand = new();
                float velocityX = MathF.Cos(Projectile.rotation - MathHelper.PiOver2) * DefaultSpeed + rand.Next(-2, 2);
                float velocityY = MathF.Sin(Projectile.rotation - MathHelper.PiOver2) * DefaultSpeed + rand.Next(-2, 2);
                Vector2 totalVelocity = new(velocityX, velocityY);

                //position calcs
                Vector2 position = Projectile.Center;
                Vector2 prismDir = Vector2.Normalize(Projectile.velocity);
                position += prismDir * 16f + new Vector2(0f, -Projectile.gfxOffY);
                position += prismDir * -17f;

                //posotions calcs
                SoundEngine.PlaySound(new SoundStyle("RS4A/Sounds/FirstPrismFire")
                {
                    Volume = 0.6f,
                    MaxInstances = 0
                });
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, totalVelocity, ModContent.ProjectileType<FirstPrismSpray>(), 5, 3);
            }
        }


        private void UpdateAnimation()
        {
            Projectile.frameCounter++;

            // As the Prism charges up and focuses the beams, its animation plays faster.
            int framesPerAnimationUpdate = FrameCounter >= MaxCharge ? 2 : FrameCounter >= (MaxCharge * 0.66f) ? 3 : 4;


            // If necessary, change which specific frame of the animation is displayed.
            if (Projectile.frameCounter >= framesPerAnimationUpdate)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= NumAnimationFrames)
                {
                    Projectile.frame = 0;
                }
            }
        }

        private void UpdatePlayerVisuals(Player player, Vector2 playerHandPos)
        {
            // Place the Prism directly into the player's hand at all times.
            Projectile.Center = playerHandPos;
            // The beams emit from the tip of the Prism, not the side. As such, rotate the sprite by pi/2 (90 degrees).
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.spriteDirection = Projectile.direction;

            // The Prism is a holdout Projectile, so change the player's variables to reflect that.
            // Constantly resetting player.itemTime and player.itemAnimation prevents the player from switching items or doing anything else.
            player.ChangeDir(Projectile.direction);
            player.heldProj = Projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;

            // If you do not multiply by Projectile.direction, the player's hand will point the wrong direction while facing left.
            player.itemRotation = (Projectile.velocity * Projectile.direction).ToRotation();
        }

        private void UpdateAim(Vector2 source, float speed)
        {
            // Get the player's current aiming direction as a normalized vector.
            Vector2 aim = Vector2.Normalize(Main.MouseWorld - source);
            if (aim.HasNaNs())
            {
                aim = -Vector2.UnitY;
            }

            // Change a portion of the Prism's current velocity so that it points to the mouse. This gives smooth movement over time.
            aim = Vector2.Normalize(Vector2.Lerp(Vector2.Normalize(Projectile.velocity), aim, AimResponsiveness));
            aim *= speed;

            if (aim != Projectile.velocity)
            {
                Projectile.netUpdate = true;
            }
            Projectile.velocity = aim;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int spriteSheetOffset = frameHeight * Projectile.frame;
            Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

            // The Prism is always at full brightness, regardless of the surrounding light. This is equivalent to it being its own glowmask.
            // It is drawn in a non-white color to distinguish it from the vanilla Last Prism.
            Color drawColor = FirstPrism.OverrideColor;

            Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), drawColor, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0f);
            return false;
        }
    }


}
