  
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
			item.damage = 15;
			item.melee = true;
			item.scale = 1f;
			item.width = 50;//changes this
			item.height = 50;//changes this
			item.useTime = 90;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 99999999;
			item.value = 100000;
			item.rare = ItemRarityID.Pink;
			item.crit = 999;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}
      
        
	}
}
