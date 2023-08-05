﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Projectiles
{
    public class sonicDartP : ModProjectile
    {
        int speed = 0;
        public override void SetStaticDefaults()
        {

            // DisplayName.SetDefault("hand");

        }
        public override void SetDefaults()
        {
            Projectile.scale = 0.5f;
            Projectile.damage = 10;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 30;
            Projectile.height = 9;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = true;
            Projectile.velocity *= 1.9f;
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            speed = Math.Abs((int)Math.Round(Main.LocalPlayer.velocity.X + Main.LocalPlayer.velocity.Y));
            Projectile.damage = Projectile.damage + speed * 3;
            if (speed > 20)
            {
                modifiers.SetCrit(); //lol?
                if (speed > 30)
                {
                    target.AddBuff(BuffID.Ichor, 600);
                    target.AddBuff(BuffID.CursedInferno, 240);

                }
            }
        }
        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
        }
    }
}
