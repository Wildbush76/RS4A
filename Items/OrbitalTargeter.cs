using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace RS4A.Items
{
    internal class OrbitalTargeter : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.rare = ItemRarityID.Expert;
            Item.consumable = false;

            //testing
            Item.buffTime = 300;
            Item.buffType = ModContent.BuffType<Buffs.OrbitalStrike>();
            
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LihzahrdPowerCell, 3);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.MechanicalBatteryPiece, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
