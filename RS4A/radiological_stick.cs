using RS4A.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
	public class radiological_stick : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Radiological Stick"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Don't burn yourself.");
		}

		public override void SetDefaults() 
		{
			item.damage = 2;
			item.melee = true;
			item.scale = 1;
			item.width = 60;
			item.height = 60;
			item.useTime = 34;
			item.useAnimation = 34;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3;
			item.value = 1;
			item.rare = ItemRarityID.Lime;
			item.crit = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Uranium_bar>(),1);
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			// Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
			// 60 frames = 1 second
				target.AddBuff(ModContent.BuffType<Rad>(), 120);
		}
	}
}
