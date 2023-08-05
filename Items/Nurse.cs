using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
	public class Nurse : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Nurse sword"); 
			// Tooltip.SetDefault("The Nurse's soul is stuck in here");
		}

		public override void SetDefaults() 
		{
			Item.damage = 1;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.scale = 1.25f;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 100000;
			Item.rare = ItemRarityID.Gray;
			Item.crit = 45;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
			player.statLife += 40;
        }
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LifeCrystal, 3);
			recipe.AddIngredient(ItemID.TargetDummy,1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.Register();
		}
	}
}
