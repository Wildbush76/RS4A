﻿using Microsoft.Xna.Framework;
using System;
using RS4A.Biomes.BlockCount;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.GameContent.RGB;
using Steamworks;

namespace RS4A.Biomes
{
    public class BrazilUndergroundBiome : ModBiome
    {
        // Select all the scenery
        public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.GetInstance<BrazilUndergroundBackgroundStyle>();
        public override ModWaterStyle WaterStyle => ModContent.GetInstance<BrazilWaterStyle>(); // Sets a water style for when inside this biome

        // Select Music
        public override int Music => MusicLoader.GetMusicSlot("RS4A/Music/UEZ");

        // Sets how the Scene Effect associated with this biome will be displayed with respect to vanilla Scene Effects. For more information see SceneEffectPriority & its values.
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh; // We have set the SceneEffectPriority to be BiomeLow for purpose of example, however default behavior is BiomeLow.
        public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Jungle;


        // Populate the Bestiary Filter
        public override string BestiaryIcon => base.BestiaryIcon;
        public override string BackgroundPath => base.BackgroundPath;
        public override Color? BackgroundColor => base.BackgroundColor;

        // Calculate when the biome is active.
        public override bool IsBiomeActive(Player player)
        {
            // Limit the biome height to be underground in either rock layer or dirt layer
            return (player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight) &&
                // Check how many tiles of our biome are present, such that biome should be active
                ModContent.GetInstance<BrazilBiomeTileCount>().brazilBlockCount >= 70;
        }
        public override void SpecialVisuals(Player player, bool isActive) // TODO: find better function to attach this to.
        { //also compensates for underground (i think)
            if (isActive)
            {
                player.AddBuff(ModContent.BuffType<Buffs.REZ>(), 10);
            }
        }
    // In the event that both our biome AND one or more modded SceneEffect layers are active with the same SceneEffect Priority, this can decide which one.
    // It's uncommon that need to assign a weight - you'd have to specifically believe that you don't need higher SceneEffectPriority, but do need to be the active SceneEffect within the priority you designated
    // In this case, we don't need it, so this inclusion is purely to demonstrate this is available.
    // See the GetWeight documentation for more information.
    /*
    public override float GetWeight(Player player) {
        int distanceToCenter = Math.Abs(player.position.ToTileCoordinates().X - Main.maxTilesX / 2);
        // We declare that our biome should have be more likely than not to be active if in center 1/6 of the world, and decreases in need to be active as player gets further away to the 1/3 mark.
        if (distanceToCenter <= Main.maxTilesX / 12) {
            return 1f;
        }
        else {
            return 1f - (distanceToCenter - Main.maxTilesX / 12) / (Main.maxTilesX / 12);
        }
    }
    */
}
}