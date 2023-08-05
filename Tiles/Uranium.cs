using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Threading;

namespace RS4A.Tiles
{
public class Uranium : ModTile
{
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileLighted[Type] = true;
            //Main.tileBlockLight[Type] = true;
           Main.tileSpelunker[Type] = true;
           // Main.tileShine2[Type] = false;

            HitSound = SoundID.Tink;
            // name.SetDefault("Uranium");
            AddMapEntry(new Color(0, 255, 120), CreateMapEntryName());
            MinPick = 200;
            MineResist = 5f;
        }
        public override void FloorVisuals(Player player)
        {
            
            player.AddBuff(Mod.Find<ModBuff>("Rad").Type,300);
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = .8f;
            b = .6f;
        }
    }
}

