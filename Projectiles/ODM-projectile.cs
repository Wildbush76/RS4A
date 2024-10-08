using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
 
    public class ODM : ModProjectile
    {
        private static Asset<Texture2D> chainTexture;

        public override void Load()
        { // This is called once on mod (re)load when this piece of content is being loaded.
          // This is the path to the texture that we'll use for the hook's chain. Make sure to update it.
            chainTexture = ModContent.Request<Texture2D>("RS4A/Projectiles/ODM_chain");
        }

        public override void Unload()
        { // This is called once on mod reload when this piece of content is being unloaded.
          // It's currently pretty important to unload your static fields like this, to avoid having parts of your mod remain in memory when it's been unloaded.
            chainTexture = null;
        }

        /*
        public override void SetStaticDefaults() {
            // If you wish for your hook projectile to have ONE copy of it PER player, uncomment this section.
            ProjectileID.Sets.SingleGrappleHook[Type] = true;
        }
        */

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.GemHookAmethyst); // Copies the attributes of the Amethyst hook's projectile.
        }

        // Use this hook for hooks that can have multiple hooks mid-flight: Dual Hook, Web Slinger, Fish Hook, Static Hook, Lunar Hook.
        public override void UseGrapple(Player player, ref int type)
        {
            int hooksOut = 0;
            int oldestHookIndex = -1;
            int oldestHookTimeLeft = 100000;
            for (int i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Projectile.whoAmI && Main.projectile[i].type == Projectile.type)
                {
                    hooksOut++;
                    if (Main.projectile[i].timeLeft < oldestHookTimeLeft)
                    {
                        oldestHookIndex = i;
                        oldestHookTimeLeft = Main.projectile[i].timeLeft;
                    }
                }
            }
            if (hooksOut > 1)
            {
                Main.projectile[oldestHookIndex].Kill();
            }
        }


        public override bool PreAI()
        {
            Player owner = Main.player[Projectile.owner];
            if (Vector2.Distance(owner.Center + owner.velocity, Projectile.Center) < 70 && Projectile.velocity == Vector2.Zero)
            {
                Projectile.Kill();//kills hook when player near 
                return false;
            }
            return true;
        }
        public override float GrappleRange()
        {
            return 850f;
        }

        public override void NumGrappleHooks(Player player, ref int numHooks)
        {
            numHooks = 1;
        }
        public override void GrapplePullSpeed(Player player, ref float speed)
        {
            speed = 35f;
        }

        public override void GrappleRetreatSpeed(Player player, ref float speed)
        {
            speed = 50f;
        }

        // Adjusts the position that the player will be pulled towards. This will make them hang 50 pixels away from the tile being grappled.
        public override void GrappleTargetPoint(Player player, ref float grappleX, ref float grappleY)
        {
            Vector2 dirToPlayer = Projectile.DirectionTo(player.Center);
            float hangDist = 50f;
            grappleX += dirToPlayer.X * hangDist;
            grappleY += dirToPlayer.Y * hangDist;
        }

        // Can customize what tiles this hook can latch onto, or force/prevent latching all together, like Squirrel Hook also latching to trees
        public override bool? GrappleCanLatchOnTo(Player player, int x, int y)
        {
            // By default, the hook returns null to apply the vanilla conditions for the given tile position (this tile position could be air or an actuated tile!)
            // If you want to return true here, make sure to check for Main.tile[x, y].HasUnactuatedTile (and Main.tileSolid[Main.tile[x, y].TileType] and/or Main.tile[x, y].HasTile if needed)

            // We make this hook latch onto trees just like Squirrel Hook

            // Tree trunks cannot be actuated so we don't need to check for that here
            Tile tile = Main.tile[x, y];
            if (TileID.Sets.IsATreeTrunk[tile.TileType] || tile.TileType == TileID.PalmTree)
            {
                return true;
            }

            // In any other case, behave like a normal hook
            return null;
        }

        // Draws the grappling hook's chain.
        public override bool PreDrawExtras()
        {
            Vector2 playerCenter = Main.player[Projectile.owner].MountedCenter;
            Vector2 center = Projectile.Center;
            Vector2 directionToPlayer = playerCenter - Projectile.Center;
            float chainRotation = directionToPlayer.ToRotation() - MathHelper.PiOver2;
            float distanceToPlayer = directionToPlayer.Length();

            while (distanceToPlayer > 20f && !float.IsNaN(distanceToPlayer))
            {
                directionToPlayer /= distanceToPlayer; // get unit vector
                directionToPlayer *= chainTexture.Height(); // multiply by chain link length

                center += directionToPlayer; // update draw position
                directionToPlayer = playerCenter - center; // update distance
                distanceToPlayer = directionToPlayer.Length();

                Color drawColor = Lighting.GetColor((int)center.X / 16, (int)(center.Y / 16));

                // Draw chain
                Main.EntitySpriteDraw(chainTexture.Value, center - Main.screenPosition,
                    chainTexture.Value.Bounds, drawColor, chainRotation,
                    chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0);
            }
            // Stop vanilla from drawing the default chain.
            return false;
        }
    }
}
