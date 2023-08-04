using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
	public class Nurse : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Nurse sword"); 
			Tooltip.SetDefault("The Nurse's soul is stuck in here");
		}

		public override void SetDefaults() 
		{
			item.damage = 1;
			item.melee = true;
			item.scale = 1.25f;
			item.width = 50;
			item.height = 50;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 100000;
			item.rare = ItemRarityID.Gray;
			item.crit = 45;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			player.statLife += 40;
        }
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LifeCrystal, 3);
			recipe.AddIngredient(ItemID.TargetDummy,1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
