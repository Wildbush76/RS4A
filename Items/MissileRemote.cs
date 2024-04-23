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
        public Dictionary<String, List<Point16>> launchLocationsByWorld;


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
            foreach(Point16 location in launchLocationsByWorld[Main.worldName]) {
                Tile tile = Main.tile[location];
                //TODO launch all of the things
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

        public void addLaunchLocation(Point16 location) { 
            if(launchLocationsByWorld.TryGetValue(Main.worldName, out List<Point16> locations))
            {
                locations.Add(location);
            }
            else
            {
                launchLocationsByWorld[Main.worldName] = new List<Point16>(locations);
            }
        }
    }
}
