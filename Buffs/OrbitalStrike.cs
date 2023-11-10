using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace RS4A.Buffs
{
    internal class OrbitalStrike : ModBuff
    {
        private readonly Random random = new Random();
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
           
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
           // BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.buffTime[buffIndex] == 1) {
                Projectile.NewProjectile(player.GetSource_FromAI(), new Vector2(player.position.X, player.position.Y - Main.screenHeight), new Vector2(0, 30),ProjectileID.Dynamite,3000,2);
            }
            /*
            float angle = (float)(random.NextDouble() * MathF.PI *2);
            float distance = random.Next(20,50);
            int x = (int)(distance * MathF.Sin(angle) + player.position.X);
            int y = (int)(distance * MathF.Cos(angle) + player.position.Y);
            Dust d = Dust.NewDustDirect(new Vector2(x,y),8,8, ModContent.DustType<Dusts.OrbitalStrikeCharge>(), 0,0);
            d.customData = player;
            
            */
            //spawn some dust that gravites toward the player
        }
    }
}
