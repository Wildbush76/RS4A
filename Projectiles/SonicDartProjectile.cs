using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Projectiles
{
    public class SonicDartProjectile : ModProjectile
    {
        private const int MAX_DAMAGE_BONUS = 30;
        public override void SetDefaults()
        {
            Projectile.scale = 0.5f;
            Projectile.damage = 10;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.width = 30;
            Projectile.height = 9;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = true;
            //Projectile.velocity *= 1.9f;
        }

        public override void OnSpawn(IEntitySource source)
        {
            Projectile.velocity += Main.player[Projectile.owner].velocity;

        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            int speed = (int)Projectile.velocity.Length();
            int damage = Math.Min((speed - 20) * 3, MAX_DAMAGE_BONUS);
            if (damage > 0)
            {
                Projectile.damage += damage;
            }
            if (speed > 20)
            {
                modifiers.SetCrit();
                if (speed > 30)
                {
                    target.AddBuff(BuffID.Ichor, 600);
                    target.AddBuff(BuffID.CursedInferno, 240);
                }
            }
        }
        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
        }
    }
}
