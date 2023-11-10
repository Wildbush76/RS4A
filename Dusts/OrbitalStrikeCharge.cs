using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Graphics;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace RS4A.Dusts
{
    internal class OrbitalStrikeCharge : ModDust
    {
        private double size;
        private const float shrinkRate = 0.01f;
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = false;
        }
           
        
        public override bool Update(Dust dust)
        {
            dust.scale -= shrinkRate;
            if (dust.customData != null && dust.customData is Player followPlayer)
            {
                float mag = 10f / MathF.Sqrt(MathF.Pow(dust.position.X - followPlayer.position.X, 2) + MathF.Pow(dust.position.Y - followPlayer.position.Y, 2));
                float angle = MathF.Atan2(dust.position.Y - followPlayer.position.Y, dust.position.X - followPlayer.position.X);
                dust.velocity += new Vector2(mag * MathF.Sin(angle), mag * MathF.Cos(angle));
            }
            if (dust.scale < 0.5) {
                dust.active = false;
            }
            return false;
        }
    }
}
