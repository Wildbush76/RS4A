using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RS4A.Projectiles;



namespace RS4A.Items
{
	public class hand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Hand");
			Tooltip.SetDefault("Botttom Text");
		}

		public override void SetDefaults()
		{
			Item.shootSpeed = 20f;
			Item.damage = 60;
			Item.scale = 1f;
			Item.width = 30;
			Item.height = 24;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 1;
			Item.value = 1000;
			Item.rare = ItemRarityID.Lime;
			Item.crit = 20;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Ranged;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Throwing;
			Item.shoot = ModContent.ProjectileType<handT>();
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 100);
			recipe.AddIngredient(ItemID.FlaskofVenom, 15);
			recipe.AddIngredient(ItemID.TitanGlove, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
