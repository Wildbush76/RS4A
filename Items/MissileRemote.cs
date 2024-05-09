using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using RS4A.PlayerStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace RS4A.Items
{
    internal class MissileRemote : ModItem
    {
        private readonly Dictionary<string, List<Point16>> launchLocationsByWorld = [];


        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 1;
            Item.knockBack = 1.2f;
            Item.rare = ItemRarityID.Red;
            Item.useStyle = ItemUseStyleID.HoldUp;
            
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI != Main.myPlayer)
            {
                return false;
            }

            return FireMissile(Main.MouseWorld);
        }

        public bool FireMissile(Vector2 target)
        {
            bool launched = false;
            if (!launchLocationsByWorld.TryGetValue(Main.worldName,out List<Point16> locations))
            {
                return false;
            }


            List<Point16> locationsToRemove = [];
            Random random = new();
            foreach (Point16 location in locations)
            {
                if (Main.tile[location].TileFrameX > 18 && MissileSystem.missilesToLaunch.All(item => item.siloLocation != location))
                {
                    launched = true;
                    MissileSystem.missilesToLaunch.Add(new RS4AUtils.MissileLaunchInfo(random.Next(60, 180), location, target));
                }
            }

            locationsToRemove.ForEach(item => launchLocationsByWorld[Main.worldName].Remove(item));
            return launched;
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("locations", launchLocationsByWorld.Select(kvp => new TagCompound()
            {
                ["world"] = kvp.Key,
                ["worldLocations"] = kvp.Value.ConvertAll<TagCompound>(value => new TagCompound()
                {
                    ["X"] = value.X,
                    ["Y"] = value.Y
                })
            }).ToList());
        }

        public override void LoadData(TagCompound tag)
        {

            if (tag.GetList<TagCompound>("locations") is List<TagCompound> locations)
            {
                foreach (TagCompound compound in locations)
                {
                    List<Point16> worldLocations = [];
                    foreach (TagCompound point in compound.GetList<TagCompound>("worldLocations"))
                    {
                        worldLocations.Add(new Point16(point.GetShort("X"), point.GetShort("Y")));
                    }
                    launchLocationsByWorld.Add(compound.GetString("world"), worldLocations);
                }

            }

        }
        public void AddLaunchLocation(Point16 location)
        {

            if (launchLocationsByWorld.TryGetValue(Main.worldName, out List<Point16> locations))
            {
                if (!locations.Contains(location))
                {
                    ChatHelper.SendChatMessageToClient(NetworkText.FromLiteral("Adding launch location!"), Color.Crimson, Main.myPlayer);
                    locations.Add(location);
                }
            }
            else
            {
                ChatHelper.SendChatMessageToClient(NetworkText.FromLiteral("Adding launch location!"), Color.Crimson, Main.myPlayer);
                locations = [location];
                launchLocationsByWorld.Add(Main.worldName, locations);
            }
        }

        public void RemoveLaunchLocation(Point16 location)
        {
            if (launchLocationsByWorld.TryGetValue(Main.worldName, out List<Point16> locations) && locations.Contains(location))
            {
                locations.Remove(location);
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.Radar);
            recipe.AddIngredient(ItemID.Wire, 10);
            recipe.AddIngredient(ItemID.Switch,10);
            recipe.Register();
        }
    }
}
