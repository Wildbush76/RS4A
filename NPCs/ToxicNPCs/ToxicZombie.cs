using RS4A.Biomes;
using System;
using System.IO;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ModLoader.Utilities;

namespace RS4A.NPCs.ToxicNPCs
{
    //The ExampleZombieThief is essentially the same as a regular Zombie, but it steals ExampleItems and keep them until it is killed, being saved with the world if it has enough of them.
    public class ToxicZombie : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Zombie];

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 90;
            NPC.defense = 30;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 1f;
            NPC.knockBackResist = 0.8f; //yes
            NPC.aiStyle = 3;

            AIType = NPCID.Zombie; // Use vanilla zombie's type when executing AI code. (This also means it will try to despawn during daytime)
            AnimationType = NPCID.Zombie; // Use vanilla zombie's type when executing animation code. Important to also match Main.npcFrameCount[NPC.type] in SetStaticDefaults.
            Banner = Item.NPCtoBanner(NPCID.Zombie); // Makes this NPC get affected by the normal zombie banner.
            BannerItem = Item.BannerToItem(Banner); // Makes kills of this NPC go towards dropping the banner it's associated with.
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("An above average zombie. It appears that the gamma rays has boosted its physical abilities."),
            });
        }


        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // Can only spawn in the ExampleSurfaceBiome and if there are no other ExampleZombieThiefs
            if (spawnInfo.Player.InModBiome(ModContent.GetInstance<BrazilSurfaceBiome>()))
            {
                return SpawnCondition.OverworldNightMonster.Chance; // Spawn with 1/10th the chance of a regular zombie.
            }

            return 0f;
        }
    }
}