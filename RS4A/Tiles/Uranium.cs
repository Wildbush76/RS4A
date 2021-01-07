using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Tiles
{
public class Uranium : ModTile
{
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;

            drop = mod.ItemType("Uranium_or");

            soundType = SoundID.Tink;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Uranium");
            AddMapEntry(new Color(0, 255, 120),name);

            minPick = 200;
            mineResist = 10f;

        }

    }
}
