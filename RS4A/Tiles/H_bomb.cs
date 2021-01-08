using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Tiles
{
public class H_bomb : ModTile
{
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileLavaDeath[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;

            drop = mod.ItemType("Uranium_or");

            soundType = SoundID.Tink;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Hydrogen Bomb");
            AddMapEntry(new Color(255,125,0),name);

            minPick = 50;
            mineResist = 10f;

        }
        public override void HitWire(int i, int j)
        {
            int radius = 10;
            while (radius < 40)
            {
                Vector2 position = Main.sceneTilePos;
                Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);


                for (int x = -radius; x <= radius; x++)
                {
                    for (int y = -radius; y <= radius; y++)
                    {
                        int xPosition = (int)(x + position.X / 16.0f);
                        int yPosition = (int)(y + position.Y / 16.0f);

                        if (Math.Sqrt(x * x + y * y) <= radius + 0.5)   //this make so the explosion radius is a circle
                        {
                            
                            WorldGen.KillTile(xPosition, yPosition, false, false, false);  //this make the explosion destroy tiles  
                            Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);  //this is the dust that will spawn after the explosion
                        }
                    }
                }
                radius++;
                Thread.Sleep(500);
            }
        }

    }
}

