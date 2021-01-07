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

    }
}
