
using RS4A.RS4AUtils;
using RS4A.Systems;
using RS4A.Tiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Projectiles
{
    public class HydrogenBombExplosion : ModProjectile
    {
        private readonly ProceduralExplosion explosion = new()
        {
            BlastRadius = 140,
            CraterLayers = 20,
            DamageRadius = 180 * 8,
            CrateringTiles = [ModContent.TileType<RadioactiveStone>(), TileID.Hellstone, ModContent.TileType<RadioactiveStone>()],
            MaxDamage = 10000,
            DeathMessages = ["Mods.RS4A.DeathMessages.HydrogenBomb.Death-1", "Mods.RS4A.DeathMessages.HydrogenBomb.Death-2", "Mods.RS4A.DeathMessages.HydrogenBomb.Death-3", "Mods.RS4A.DeathMessages.HydrogenBomb.Death-4", "Mods.RS4A.DeathMessages.HydrogenBomb.Death-5"]
        };

        public override void SetDefaults()
        {
            Projectile.hostile = true;
            Projectile.friendly = false;
            Projectile.width = 32;
            Projectile.height = 16;
            Projectile.Opacity = 0;
        }


        public override void AI()
        {

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                Projectile.Kill();
                return;
            }

            if (!explosion.Exploding)
            {
                explosion.InitExplosion(Projectile.Center);
                NuclearFlash.TriggerFlash();
                SoundEngine.PlaySound(new SoundStyle($"{nameof(RS4A)}/Sounds/hydrogenBomb")
                {
                    Volume = 0.6f,
                    PitchVariance = 0.2f
                });
            }
            else
            {
                if (explosion.ProcessExplosion())
                    Projectile.Kill();
            }
        }

    }
}
