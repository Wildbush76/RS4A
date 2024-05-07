using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Projectiles
{
    public class SonicDartProjectile : ModProjectile
    {
        private const int MAX_DAMAGE = 30;
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
            Projectile.velocity *= 1.9f;
        }

        public override void OnSpawn(IEntitySource source)
        {
            Projectile.velocity += Main.player[Projectile.owner].velocity;
            
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            int speed = (int)Projectile.velocity.Length();

            Projectile.damage = Projectile.damage + speed * 3;
            Projectile.damage = Math.Min(Projectile.damage, MAX_DAMAGE);
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
