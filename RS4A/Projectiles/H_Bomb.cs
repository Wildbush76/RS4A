using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RS4A.Tiles;
namespace RS4A.Projectiles
{
	public class H_Bomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{

			DisplayName.SetDefault("Nuke");

		}
		public override void SetDefaults()
		{
			projectile.damage = 500;
			projectile.friendly = false;
			projectile.ranged = true;
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 16;
			projectile.penetrate = 1;
			projectile.timeLeft = 180;
		}
		public override void Kill(int timeLeft)
		{

			bool f = false;
			Vector2 position = projectile.Center;
			Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
			Random crat = new Random();
			int radius = 60;
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
							if (f == true && Framing.GetTileSafely(xPosition, yPosition).active())
							{
								int xadd = crat.Next(1,7);
								int yadd = crat.Next(1,7);
								int xsub = crat.Next(1, 7);
								int ysub = crat.Next(1, 7);
								int fill = crat.Next(1, 11);
								if(yadd < 5)
                                {
									yPosition++;
                                }
								if (xadd  < 5)
								{
									xPosition++;
								}
								if(xsub < 5)
                                {
									xPosition--;
                                }
								if(ysub < 5)
                                {
									yPosition--;
                                }
								if(fill < 9)
							    {
									WorldGen.KillTile(xPosition, yPosition, false, false, false);
								}  
									WorldGen.PlaceTile(xPosition, yPosition, ModContent.TileType<Radstone>(), true);
								

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
				radius += 5;
			}

		}



	}
}
