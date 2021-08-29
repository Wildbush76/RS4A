using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RS4A.Projectiles;



namespace RS4A.Items
{
	public class sonicDart : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sonic Dart");
			Tooltip.SetDefault("Move fast, hit hard.");
		}

		public override void SetDefaults()
		{
			item.shootSpeed = 20;
			item.damage = 10;
			item.scale = 0.5f;
			item.width = 60;
			item.height = 18;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3;
			item.value = 1000;
			item.rare = ItemRarityID.Lime;
			item.crit = 20;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.melee = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.thrown = true;
			item.shoot = ModContent.ProjectileType<sonicDartP>();
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 5);
			recipe.AddIngredient(ItemID.RainCloud, 10);
			recipe.AddIngredient(ItemID.Ruby, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
