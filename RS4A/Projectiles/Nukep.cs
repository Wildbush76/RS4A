using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Projectiles
{
	public class dyno_arrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{

			DisplayName.SetDefault("Nuke");

		}
		public override void SetDefaults()
		{
			projectile.damage = 30;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.width = 14;
			projectile.height = 32;
			projectile.aiStyle = 34;
			projectile.penetrate = 1;
			projectile.arrow = true;

		}
		public override void Kill(int timeLeft)
		{
			Vector2 position = projectile.Center;
				Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
			   
				int radius = 10;     //this is the explosion radius, the highter is the value the bigger is the explosion

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
		}



	}
	}
