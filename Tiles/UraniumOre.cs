using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Tiles
{
    public class UraniumOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileLighted[Type] = true;
            Main.tileSpelunker[Type] = true;
            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true;


            HitSound = SoundID.Tink;

            AddMapEntry(new Color(0, 100, 40), CreateMapEntryName());
            MinPick = 200;
            MineResist = 5f;
        }
        public override void FloorVisuals(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.Radiation>(), 300);
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = 0.4f;
            b = 0.3f;
        }
    }
}

