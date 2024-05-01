using RS4A.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class RadiologicalStick : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 2;
            Item.DamageType = DamageClass.MeleeNoSpeed/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.scale = 1;
            Item.width = 60;
            Item.height = 60;
            Item.useTime = 34;
            Item.useAnimation = 34;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 3;
            Item.value = 1;
            Item.rare = ItemRarityID.Lime;
            Item.crit = 0;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<UraniumOre>(), 1);
            recipe.AddIngredient(ItemID.Wood, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Radiation2>(), 180);
        }
        public override void UpdateInventory(Player player)
        {
            player.AddBuff(ModContent.BuffType<Radiation3>(), 10);
        }
        public override void HoldItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Radiation3>(), 10);
        }
    }
}
