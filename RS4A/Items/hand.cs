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
			item.shootSpeed = 20f;
			item.damage = 30;
			item.scale = 1f;
			item.width = 30;
			item.height = 24;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 1;
			item.value = 1000;
			item.rare = ItemRarityID.Lime;
			item.crit = 20;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.ranged = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.thrown = true;
			item.shoot = ModContent.ProjectileType<handT>();
		}
	}
}
