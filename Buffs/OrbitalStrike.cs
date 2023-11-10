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
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
           
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
           BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.buffTime[buffIndex] == 1) {
                Projectile.NewProjectile(player.GetSource_FromAI(), new Vector2(player.position.X - 50, player.position.Y - 50), new Vector2(0, 0),ModContent.ProjectileType<Projectiles.Targeting>(),1,1);
            }
       
        }
    }
}
