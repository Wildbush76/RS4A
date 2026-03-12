
using RS4A.RS4AUtils;
using RS4A.Systems;
using RS4A.Tiles;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Projectiles
{
    public class HydrogenBombProjectile : ModProjectile
    {
        private const int blastRadius = 140;//includes the burnt block radius
        private const int burntBlockLayers = 20;

        private const int playerDamageRadius = 180 * 8;
        private const int maxDamage = 9999999;
        private readonly int[] craterTiles = [ModContent.TileType<RadioactiveStone>(), TileID.Obsidian, TileID.Hellstone];



        private ProceduralExplosion explosion;
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
                    explosion = new ProceduralExplosion(Projectile.Center, blastRadius, 60) { 
                        CrateringSize = burntBlockLayers,
                        DamageRadius = playerDamageRadius,
                        CrateringTiles = craterTiles,
                        MaxDamage = maxDamage

                    };
                return true;
            }

            if (explosion.ProcessExplosion()) 
                Projectile.Kill();
                
            

         
            return false;
        }

       
    }
}
