
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Dusts
{
    internal class SmokeCloud : ModDust
    {
        public override string Texture => "Terraria/Images/Gore_" + GoreID.Smoke1;
        public override void OnSpawn(Dust dust)
        {
            dust.alpha = 0;
            dust.color = Color.Gray;
        }

        public override bool Update(Dust dust)
        {
            dust.scale += 0.1f;
            dust.alpha+=2;

            if (dust.alpha >= 255)
            {
                dust.active = false;
            }
            return false;
        }

    }
}
