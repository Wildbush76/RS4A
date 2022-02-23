using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
	public class LG : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("TRANS sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("C:");
		}

		public override void SetDefaults()
		{
			item.damage = 700;
			item.melee = true;
			item.scale = 1f;
			item.width = 50;
			item.height = 50;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 100000;
			item.rare = ItemRarityID.Pink;
			item.crit = 50;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;

		}
        public override void OnHitPvp(Player player, Player target, int damage, bool crit)
        {
			target.Male = !target.Male;

        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LivingRainbowDye,5);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
