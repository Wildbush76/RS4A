using Microsoft.Xna.Framework;
using RS4A.BossBars;
using RS4A.Systems;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.Graphics.CameraModifiers;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.NPCs.StupidBoss
{
    // The main part of the boss, usually referred to as "body"
    [AutoloadBossHead] // This attribute looks for a texture called "ClassName_Head_Boss" and automatically registers it as the NPC boss head icon
    public class StupidBossBody : ModNPC
    {
        // This boss has a second phase and we want to give it a second boss head icon, this variable keeps track of the registered texture from Load().
        // It is applied in the BossHeadSlot hook when the boss is in its second stage
        public static int secondStageHeadSlot = -1;

        public float speed = 5;

        private bool SecondStage = false;
        private int blinkingDir = 1;
        private bool blinking = false;

        public override void Load()
        {
            // We want to give it a second boss head icon, so we register one
            string texture = BossHeadTexture + "_SecondStage"; // Our texture is called "ClassName_Head_Boss_SecondStage"
            secondStageHeadSlot = Mod.AddBossHeadTexture(texture, -1); // -1 because we already have one registered via the [AutoloadBossHead] attribute, it would overwrite it otherwise
        }

        public override void BossHeadSlot(ref int index)
        {
            int slot = secondStageHeadSlot;
            if (SecondStage && slot != -1)
            {
                // If the boss is in its second stage, display the other head icon instead
                index = slot;
            }
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 8;

            // Add this in for bosses that have a summon item, requires corresponding code in the item (See MinionBossSummonItem.cs)
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            // Automatically group with other bosses
            NPCID.Sets.BossBestiaryPriority.Add(Type);

            // Specify the debuffs it is immune to. Most NPCs are immune to Confused.
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
            // This boss also becomes immune to OnFire and all buffs that inherit OnFire immunity during the second half of the fight. See the ApplySecondStageBuffImmunities method.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new()
            {
                CustomTexturePath = "ExampleMod/Assets/Textures/Bestiary/MinionBoss_Preview",
                PortraitScale = 0.6f, // Portrait refers to the full picture when clicking on the icon in the bestiary
                PortraitPositionYOverride = 0f,
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }

        public override void SetDefaults()
        {
            NPC.width = 100;
            NPC.height = 100;
            NPC.defense = 50;
            NPC.lifeMax = 20000;
            NPC.damage = 300;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.value = Item.buyPrice(copper: 1);
            NPC.SpawnWithHigherTime(30);
            NPC.boss = true;
            NPC.npcSlots = 10f; // Take up open spawn slots, preventing random NPCs from spawning during the fight

            // Default buff immunities should be set in SetStaticDefaults through the NPCID.Sets.ImmuneTo{X} arrays.
            // To dynamically adjust immunities of an active NPC, NPC.buffImmune[] can be changed in AI: NPC.buffImmune[BuffID.OnFire] = true;
            // This approach, however, will not preserve buff immunities. To preserve buff immunities, use the NPC.BecomeImmuneTo and NPC.ClearImmuneToBuffs methods instead, as shown in the ApplySecondStageBuffImmunities method below.

            // Custom AI, 0 is "bound town NPC" AI which slows the NPC down and changes sprite orientation towards the target
            NPC.aiStyle = -1;

            // Custom boss bar
            NPC.BossBar = ModContent.GetInstance<StupidBossBossBar>();

            // The following code assigns a music track to the boss in a simple way.
            if (!Main.dedServ)
            {
                Music = MusicLoader.GetMusicSlot(Mod, "Music/funkyTown");
            }
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // Sets the description of this NPC that is listed in the bestiary
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                new MoonLordPortraitBackgroundProviderBestiaryInfoElement(), // Plain black background
				new FlavorTextBestiaryInfoElement("YOU WERE MISTAKEN YOU WERE MISTAKEN YOU WERE MISTAKEN YOU WERE MISTAKEN")
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            // will drop leeroy emblem as a test
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.LeeroyEmblem>()));
        }

        public override void OnKill()
        {
            // This sets downedMinionBoss to true, and if it was false before, it initiates a lantern night
            NPC.SetEventFlagCleared(ref DownedBossSystem.downedStupidBoss, -1);

            // Since this hook is only ran in singleplayer and serverside, we would have to sync it manually.
            // Thankfully, vanilla sends the MessageID.WorldData packet if a BOSS was killed automatically, shortly after this hook is ran

            // If your NPC is not a boss and you need to sync the world (which includes ModSystem, check DownedBossSystem), use this code:
            /*
			if (Main.netMode == NetmodeID.Server) {
				NetMessage.SendData(MessageID.WorldData);
			}
			*/
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            // Here you'd want to change the potion type that drops when the boss is defeated. Because this boss is early pre-hardmode, we keep it unchanged
            // (Lesser Healing Potion). If you wanted to change it, simply write "potionType = ItemID.HealingPotion;" or any other potion type
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = ImmunityCooldownID.Bosses; // use the boss immunity cooldown counter, to prevent ignoring boss attacks by taking damage from other sources
            return true;
        }

        public override void FindFrame(int frameHeight)
        {
            // This NPC animates with a simple "go from start frame to final frame, and loop back to start frame" rule
            // In this case: First stage: 0-1-2-0-1-2, Second stage: 3-4-5-3-4-5, 5 being "total frame count - 1"
            int startFrame = 0;
            int finalFrame = 3;

            if (SecondStage)
            {
                startFrame = 4;
                finalFrame = Main.npcFrameCount[NPC.type] - 1;

                if (NPC.frame.Y < startFrame * frameHeight)
                {
                    // If we were animating the first stage frames and then switch to second stage, immediately change to the start frame of the second stage
                    NPC.frame.Y = startFrame * frameHeight;
                }
            }

            int blinkInterval = 50;
            NPC.frameCounter += 0.5f;
            if (NPC.frameCounter > blinkInterval)
            {
                blinking = true;
            }
            if (blinking)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight * blinkingDir;
                if (NPC.frame.Y > finalFrame * frameHeight)
                {
                    NPC.frame.Y = finalFrame * frameHeight;
                    blinkingDir = -1;
                }
                else if (NPC.frame.Y < startFrame * frameHeight)
                {
                    blinkingDir = 1;
                    blinking = false;
                    NPC.frame.Y = startFrame * frameHeight;

                }
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            // If the NPC dies, spawn gore and play a sound
            if (Main.netMode == NetmodeID.Server)
            {
                // We don't want Mod.Find<ModGore> to run on servers as it will crash because gores are not loaded on servers
                return;
            }

            if (NPC.life <= 0)
            {
                // These gores work by simply existing as a texture inside any folder which path contains "Gores/"
                int backGoreType = Mod.Find<ModGore>("MinionBossBody_Back").Type;//hey nerd you can use modContent rather than Mod.find
                int frontGoreType = Mod.Find<ModGore>("MinionBossBody_Front").Type;

                var entitySource = NPC.GetSource_Death();

                for (int i = 0; i < 2; i++)
                {
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);
                }

                SoundEngine.PlaySound(SoundID.Roar, NPC.Center);

                // This adds a screen shake (screenshake) similar to Deerclops
                PunchCameraModifier modifier = new(NPC.Center, (Main.rand.NextFloat() * ((float)Math.PI * 2f)).ToRotationVector2(), 20f, 6f, 20, 1000f, FullName);
                Main.instance.CameraModifiers.Add(modifier);
            }
        }

        public override void AI()
        {
            //get very close guy
            double closest = 1300;
            Player closestPlayer = null;

            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player player = Main.player[i];
                if (player.active && !player.dead)
                {
                    double dist = Vector2.Distance(NPC.Center, player.Center);
                    if (dist < closest)
                    {
                        closest = dist;
                        closestPlayer = player;
                    }
                }
            }

            if (closestPlayer == null)
            {
                // If the targeted player is dead, flee
                NPC.velocity.Y -= 0.04f;
                // This method makes it so when the boss is in "despawn range" (outside of the screen), it despawns in 10 ticks
                NPC.EncourageDespawn(30);
                return;
            }

            CheckSecondStage();


            if (SecondStage)
            {
                DoSecondStage(closestPlayer);
            }
            else
            {
                DoFirstStage(closestPlayer);
            }
        }


        private void CheckSecondStage()
        {
            if (SecondStage)
            {
                // No point checking if the NPC is already in its second stage
                return;
            }

            if (NPC.life < NPC.lifeMax / 2)
            {
                // If we have no shields (aka "no minions alive"), we initiate the second stage, and notify other players that this NPC has reached its second stage
                // by setting NPC.netUpdate to true in this tick. It will send important data like position, velocity and the NPC.ai[] array to all connected clients

                // Because SecondStage is a property using NPC.ai[], it will get synced this way
                SecondStage = true;
                NPC.netUpdate = true;
                NPC.damage = 400; //do more damag
                speed *= 2;
            }
        }

        private void DoFirstStage(Player player)
        {
            // its as shrimple as that
            Vector2 fromPlayer = player.Center - NPC.Center;
            float angle = fromPlayer.ToRotation();
            NPC.velocity = angle.ToRotationVector2() * speed;
        }

        private void DoSecondStage(Player player)
        {
            Vector2 fromPlayer = player.Center - NPC.Center;
            float angle = fromPlayer.ToRotation();
            NPC.velocity = angle.ToRotationVector2() * speed;
        }
    }
}