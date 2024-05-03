using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
    internal class OrbitalStrikeProjectile : ModProjectile
    {
        private const int blastRadius = 20;//includes the burnt block radius
        private const int burntBlockLayers = 6;
        private const float playerDamageRadius = 100 * 8;
        private const int maxDamage = 20000;
        private readonly int[] craterTiles = [TileID.Obsidian, TileID.Ash, TileID.Meteorite];
        public override void SetDefaults()
        {
            Projectile.damage = 1;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 42;
            Projectile.height = 95;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 1;
        }
        public override void OnKill(int timeLeft)
        {

            RS4AUtils.Explode.CrateringExplosion(Projectile.Center, maxDamage, blastRadius, burntBlockLayers, craterTiles, [" was never seen again", " turned to ash", " got what they deserved"]);
        }
    }
}
