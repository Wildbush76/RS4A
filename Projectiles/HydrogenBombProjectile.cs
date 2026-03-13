
using RS4A.RS4AUtils;
using RS4A.Systems;
using RS4A.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Projectiles
{
    public class HydrogenBombProjectile : ModProjectile
    {
        private ProceduralExplosion explosion = new()
        {
            BlastRadius = 140,
            CraterLayers = 20,
            DamageRadius = 180 * 8,
            CrateringTiles = [ModContent.TileType<RadioactiveStone>(), TileID.Hellstone],
            MaxDamage = 10000,
            DeathMessages = ["Mods.RS4A.DeathMessages.HydrogenBomb.Death-1", "Mods.RS4A.DeathMessages.HydrogenBomb.Death-2", "Mods.RS4A.DeathMessages.HydrogenBomb.Death-3", "Mods.RS4A.DeathMessages.HydrogenBomb.Death-4", "Mods.RS4A.DeathMessages.HydrogenBomb.Death-5"]
        };


        private int explosionCountdown = 180;

        public override void SetDefaults()
        {
            Projectile.damage = 500;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 32;
            Projectile.height = 16;
            Projectile.aiStyle = ProjAIStyleID.Explosive;
            Projectile.penetrate = 1;
        }


        public override bool PreAI()
        {
            if (explosionCountdown > 0)
            {
                explosionCountdown--;
                if (explosionCountdown == 0)
                {
                    explosion.InitExplosion(Projectile.Center);
                    NuclearFlash.TriggerFlash();
                }
                else
                    return true;
            }

            if (explosion.Exploding && explosion.ProcessExplosion())
                Projectile.Kill();

            return false;
        }


    }
}
