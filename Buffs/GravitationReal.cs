using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace RS4A.Buffs
{
    internal class GravitationReal : ModBuff
    {

        private readonly float MAX_RANGE = MathF.Pow(20, 2);
        private readonly float STRENGTH = 1;

        private readonly int particleSpawnRadius = 16 * 10;
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            foreach (Player p in Main.player)
            {

                if (p != player)
                    ApplyGravity(p, player.Center);
            }

            foreach (NPC npc in Main.npc)
            {
                if (npc is not null && npc.active)
                {
                    ApplyGravity(npc, player.Center);
                }
            }

            foreach (Projectile proj in Main.projectile)
            {
                if (proj is not null && proj.active)
                    ApplyGravity(proj, player.Center);
            }
            
        }




        private void ApplyGravity(Entity entity, Vector2 center)
        {
            float distance = center.Distance(entity.Center) / 16;

            if (distance > MAX_RANGE)
                return;



            float acceleration = Math.Min(STRENGTH / distance, STRENGTH);
            //float acceleration = 1;
            float direction = MathF.Atan2(entity.Center.Y - center.Y, entity.Center.X - center.X);



            entity.velocity -= new Vector2(acceleration * MathF.Cos(direction), acceleration * MathF.Sin(direction));
            //entity.velocity.Y -= 0.1f;
        }

    }
}
