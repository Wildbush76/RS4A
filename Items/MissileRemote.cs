using Microsoft.Xna.Framework;
using RS4A.Tiles;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace RS4A.Items
{
    internal class MissileRemote : ModItem
    {
        public Dictionary<string, List<Point16>> launchLocationsByWorld = new();


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
            bool launched = false;
            if (!launchLocationsByWorld.ContainsKey(Main.worldName) || player.whoAmI != Main.myPlayer) {
                return false;
            }
            foreach(Point16 location in launchLocationsByWorld[Main.worldName]) {
                Tile tile = Main.tile[location];
                if (TileLoader.GetTile(tile.TileType) is Tiles.MissileSilo silo) {
                    launched = true;
                    Main.NewText("Launching Missile!");
                    silo.Launch(location.X,location.Y,Point16.Zero);
                }
                    
            }
            return launched;
        }

        public override void SaveData(TagCompound tag)
        {
            //TODO figure this out later
        }

        public override void LoadData(TagCompound tag)
        {
//TODO figure this out later
        }

        public void AddLaunchLocation(Point16 location) {
            
            if(launchLocationsByWorld.TryGetValue(Main.worldName, out List<Point16> locations))
            {
                if (!locations.Contains(location))
                {
                    Main.NewText("Added launch location", new Color(150, 0, 0));
                    locations.Add(location);
                }
            }
            else
            {
                Main.NewText("Added launch location", new Color(150, 0, 0));
                locations = new()
                {
                    location
                };
                launchLocationsByWorld.Add(Main.worldName, locations);
            }
        }
    }
}
