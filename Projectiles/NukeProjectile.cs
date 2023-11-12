using Microsoft.Xna.Framework;
using RS4A.Tiles;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
namespace RS4A.Projectiles
{
    public class NukeProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.damage = 150;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = 34;
            Projectile.penetrate = 1;

        }
        public override void OnKill(int timeLeft)
        {
            bool f = false;
            Vector2 position = Projectile.Center;
            SoundEngine.PlaySound(SoundID.Item14, position);
            Random q = new();
            int radius = 10;
            for (int k = 0; k < 2; k++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    for (int y = -radius; y <= radius; y++)
                    {
                        int xPosition = (int)(x + position.X / 16.0f);
                        int yPosition = (int)(y + position.Y / 16.0f);

                        if (Math.Sqrt(x * x + y * y) <= radius + 0.5)
                        {
                            if (f == true && Framing.GetTileSafely(xPosition, yPosition).HasTile)
                            {

                                int a = q.Next(1, 5);
                                if (a == 2)
                                {
                                    //testing thingy
                                    WorldGen.KillTile(xPosition, yPosition, false, false, false);
                                    WorldGen.PlaceTile(xPosition, yPosition, ModContent.TileType<RadioactiveStone>(), true);
                                }
                            }
                            if (f == false)
                            {
                                WorldGen.KillTile(xPosition, yPosition, false, false, false);
                                Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);
                            }
                        }
                    }
                }
                f = true;
                radius += 4;
            }
        }



    }
}
