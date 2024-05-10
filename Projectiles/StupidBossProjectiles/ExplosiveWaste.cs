using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using RS4A.Tiles;
using Terraria.DataStructures;
using RS4A.Buffs;

namespace RS4A.Projectiles.StupidBossProjectiles
{
    public class ExplosiveWaste : ModProjectile
    {
        private const int blastRadius = 10;//includes the burnt block radius
        private const float playerDamageRadius = 10 * 8;
        private const int maxDamge = 150; //KILL
        private readonly int[] craterTiles = { ModContent.TileType<RadioactiveStone>() };

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.alpha = 0;
            Projectile.timeLeft = 10000;
            Projectile.penetrate = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.netImportant = true;
            Projectile.aiStyle = 2;
            CooldownSlot = ImmunityCooldownID.Bosses; // use the boss immunity cooldown counter, to prevent ignoring boss attacks by taking damage from other sources
        }

        public override Color? GetAlpha(Color lightColor)
        {
            // When overriding GetAlpha, you usually want to take the projectiles alpha into account. As it is a value between 0 and 255,
            // it's annoying to convert it into a float to multiply. Luckily the Opacity property handles that for us (0f transparent, 1f opaque)
            return Color.White * Projectile.Opacity;
        }
        public override void OnKill(int timeLeft) //thank ye henry
        {
            RS4AUtils.Explode.CrateringExplosion(Projectile.Center, 0, 10, 10, [ModContent.TileType<RadioactiveStone>()], [" was reduced to sub-atomic ash", " was no more", " suddenly stopped existing"],ModContent.BuffType<Radiation>(),60);
        }
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            Main.NewText(Projectile.ai[1]);
            if (Projectile.ai[1] == 1)
            {
                fallThrough = false;
            }
            return true;
        }
    }
}