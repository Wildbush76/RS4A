using RS4A.Tiles;
using Terraria;
using Terraria.ModLoader;
namespace RS4A.Projectiles
{
    public class HydrogenBombProjectile : ModProjectile
    {
        private const int blastRadius = 140;//includes the burnt block radius
        private const int burntBlockLayers = 30;
        private const float playerDamageRadius = 180 * 8;
        private const int maxDamage = 9999999;
        private readonly int[] craterTiles = [ModContent.TileType<RadioactiveStone>()];
        public override void SetDefaults()
        {
            Projectile.damage = 500;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 32;
            Projectile.height = 16;
            Projectile.aiStyle = 16;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 180;
        }
        public override void OnKill(int timeLeft)
        {
            RS4AUtils.Explode.CrateringExplosion(Projectile.Center, maxDamage, blastRadius, burntBlockLayers, craterTiles, [" was reduced to sub-atomic ash", " was no more", " suddenly stopped existing"]);
        }
    }
}
