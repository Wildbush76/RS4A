﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Projectiles
{
    public class handT : ModProjectile
    {
        public override void SetStaticDefaults()
        {

            // DisplayName.SetDefault("hand");

        }
        public override void SetDefaults()
        {
            Projectile.scale = 1;
            Projectile.damage = 60;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 30;
            Projectile.height = 24;
            Projectile.aiStyle = 2;
            Projectile.penetrate = 9999;
            Projectile.tileCollide = true;
            Projectile.velocity *= 1.9f;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.defense = 0; //lol
            target.AddBuff(BuffID.Venom, 240);
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

        }
        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
        }
    }
}