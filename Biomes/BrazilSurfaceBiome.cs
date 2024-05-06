using RS4A.Biomes;
//using ExampleMod.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using System;
using RS4A.Biomes.BlockCount;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.GameContent.RGB;
using Terraria.Chat;
using Terraria.Localization;

namespace RS4A.Biomes
{
    // Shows setting up two basic biomes. For a more complicated example, please request.
    public class BrazilSurfaceBiome : ModBiome
    {
        // Select all the scenery
        public override ModWaterStyle WaterStyle => ModContent.GetInstance<BrazilWaterStyle>(); // Sets a water style for when inside this biome
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<BrazilSurfaceBackgroundStyle>();
        public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Normal;

        // Select Music
        public override int Music => MusicLoader.GetMusicSlot("RS4A/Music/IRRADIATE");

        public override int BiomeTorchItemType => ItemID.Torch; //maybe changle these later if i feel like it
        public override int BiomeCampfireItemType => ItemID.Campfire;

        // Populate the Bestiary Filter
        public override string BestiaryIcon => base.BestiaryIcon;
        public override string BackgroundPath => base.BackgroundPath;
        public override Color? BackgroundColor => base.BackgroundColor;
        public override string MapBackground => BackgroundPath; // Re-uses Bestiary Background for Map Background

        // Calculate when the biome is active.
        public override bool IsBiomeActive(Player player)
        {
            // First, we will use the exampleBlockCount from our added ModSystem for our first custom condition
            bool b1 = ModContent.GetInstance<BrazilBiomeTileCount>().brazilBlockCount >= 100;

            // Finally, we will limit the height at which this biome can be active to above ground (ie sky and surface). Most (if not all) surface biomes will use this condition.
            bool b2 = player.ZoneSkyHeight || player.ZoneOverworldHeight;
            return b1 && b2;
        }

        // Declare biome priority. The default is BiomeLow so this is only necessary if it needs a higher priority.
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
        private int disabledelay = 50;
        
        public override void SpecialVisuals(Player player, bool isActive) // T
        { //also compensates for underground (i think)
            if (isActive)
            {
                player.AddBuff(ModContent.BuffType<Buffs.REZ>(), 10);
            }
        }
        
        //i hope this wasnt all in vain, but at the same time hopefully lol
        
    }
}