using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class MushuWhip : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.BlandWhip;
        public override void SetDefaults()
        {
            Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.MushuWhipProjectile>(), 30, 10, 10, 30);
            Item.damage = 170;
            Item.autoReuse = true;
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (source is EntitySource_Loot)
            {
                SoundEngine.PlaySound(new SoundStyle($"{nameof(RS4A)}/Sounds/mushuNotLizard"));
            }
        }

    }


}
