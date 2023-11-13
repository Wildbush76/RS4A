using Microsoft.Xna.Framework;
using RS4A.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Tiles
{
    public class RadioactiveStone : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileLighted[Type] = true;
            Main.tileSpelunker[Type] = true;
            HitSound = SoundID.Dig;

            AddMapEntry(new Color(0, 255, 156));
            MinPick = 200;
            MineResist = 5f;


            DustType = ModContent.DustType<RadiationDust>();
            DustType = ModContent.DustType<RadiationDust>();
            DustType = ModContent.DustType<RadiationDust>();
        }
        public override void FloorVisuals(Player player)
        {

            player.AddBuff(ModContent.BuffType<Buffs.Radiation>(), 300);
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

    }
}
