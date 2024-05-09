using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RS4A.Projectiles;



namespace RS4A.Items
{
	public class SonicDart : ModItem
	{
		public override void SetDefaults()
		{
			Item.shootSpeed = 20;
			Item.damage = 10;
			Item.scale = 0.5f;
			Item.width = 60;
			Item.height = 18;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3;
			Item.value = 1000;
			Item.rare = ItemRarityID.Lime;
			Item.crit = 20;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Throwing;
			Item.shoot = ModContent.ProjectileType<SonicDartProjectile>();
			Item.noUseGraphic = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 5);
			recipe.AddIngredient(ItemID.RainCloud, 10);
			recipe.AddIngredient(ItemID.Ruby, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
