using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class LeeroyEmblem : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.value = 0;
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;

        }
        public override void UpdateEquip(Player player)
        {
            if (player.statDefense < 100 && player.endurance < 0.50)
            { //100 is the range

              //player.GetDamage(DamageClass.Generic) += (10 - player.statDefense / 10); //this equation is dogshit
                player.GetDamage(DamageClass.Generic) += 2.0f * (1.0f - (float)player.statDefense / 100.0f) * (1f-player.endurance); //maximum of 200% damage (no defense, hard to do at post-moonlord as armor and accessories start giving the good stuff)
                ChatHelper.SendChatMessageToClient(NetworkText.FromLiteral("it is doing things"), Color.Green, Main.myPlayer);

            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WarriorEmblem);
            recipe.AddIngredient(ItemID.SummonerEmblem);
            recipe.AddIngredient(ItemID.RangerEmblem);
            recipe.AddIngredient(ItemID.SorcererEmblem);
            recipe.AddIngredient(ItemID.SoulofFlight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.LunarBar, 50);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
