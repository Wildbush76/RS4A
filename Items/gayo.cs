using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RS4A.Buffs;

namespace RS4A.Items
{
	public class Gayo : ModItem
	{
		public override void SetStaticDefaults() 
		{
			//DisplayName.SetDefault("Gay-Inator Mk1");
			//Tooltip.SetDefault("Become the gay");
		}

		public override void SetDefaults() 
		{
			Item.shootSpeed = 10f;
			Item.shoot = Mod.Find<ModProjectile>("Gayp").Type;  //add gayp here
			Item.damage = 200;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 20;
			Item.scale = 1.25f;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 2;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ItemRarityID.Expert;
			Item.crit = 100;
			Item.autoReuse = false;
	
		}

		public override void AddRecipes() 
		{
                    
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LivingRainbowDye,5);
			recipe.AddIngredient(Mod.Find<ModItem>("Uranium_bar").Type,5);
			recipe.AddIngredient(ItemID.RainbowRod,1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
      
		}
		
	}
}
