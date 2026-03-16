using Microsoft.Xna.Framework;
using RS4A.Items;
using RS4A.Projectiles;
using Terraria;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace RS4A.PlayerStuff
{
    public class RSPlayer : ModPlayer
    {
        public bool isDOT;
        public bool leadPoisoned;
        public bool radioactive; // only exists for death messages i think :)
        public int DOT;
        private readonly string deathMessages = "Mods.RS4A.Status.Death";

        public override void ResetEffects()
        {
            leadPoisoned = false;
            radioactive = false;
            DOT = 0;
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) // copied from calamity, why does damage == 10?
            {
                if (radioactive)
                {
                    var deathMessage = NetworkText.FromKey(deathMessages + ".Radiation-" + Main.rand.Next(1, 4), Player.name);
                    damageSource = PlayerDeathReason.ByCustomReason(deathMessage);
                }
            }


            return true;
        }
        public override void UpdateBadLifeRegen()
        {
            if (DOT < 0)
            {
                // These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects
                if (Player.lifeRegen > 0)
                    Player.lifeRegen = 0;
                // Player.lifeRegenTime used to increase the speed at which the player reaches its maximum natural life regeneration
                // So we set it to 0, and while this debuff is active, it never reaches it
                Player.lifeRegenTime = 0;
                // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second
                Player.lifeRegen += DOT;

            }
        }

        public override void OnHurt(Player.HurtInfo info)
        {
            if (info.Damage >= Items.HydrogenBomb.EQUIPMENT_DAMAGE_THRESHOLD) {
                for (int i = 3; i <= 9; i++)
                {
                    if (Player.armor[i].type == ModContent.ItemType<HydrogenBomb>())
                    {
                        Player.armor[i].TurnToAir();
                        Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, Vector2.Zero, ModContent.ProjectileType<HydrogenBombExplosion>(), 0, 0);
                    }
                }
            }
        }

        
    }

}