using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Steamworks;

namespace RS4A.Items
{
    public class FirstPrism : ModItem
    {
        public static Color OverrideColor = new(200, 200, 200);

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LastPrism);
            Item.shoot = ModContent.ProjectileType<Projectiles.FirstPrismHoldout>();
            Item.color = OverrideColor;
            Item.UseSound = new SoundStyle($"{nameof(RS4A)}/Sounds/FirstPrismTurnOn") {
                Volume = 1,
                PitchVariance = 0.2f,
                MaxInstances = 1
            };
            Item.damage = 0;
           

        }


        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.FirstPrismHoldout>()] <= 0;
        }

    }
}
