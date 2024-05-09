using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    internal class Missile : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 10;
        }
        public override void SetDefaults()
        {
            Item.damage = 300;
            Item.DamageType = DamageClass.Summon;
            Item.width = 20;
            Item.height = 40;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.knockBack = 1.2f;
            Item.value = 19200;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(3);
            recipe.AddIngredient(ItemID.RocketIV,3);
            recipe.AddIngredient(ItemID.Explosives,3);
            recipe.AddIngredient(ItemID.RocketBoots, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }


    }
}
