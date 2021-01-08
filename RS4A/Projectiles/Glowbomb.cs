public class Boom : ModProjectile
		{
			public override void SetDefaults()
			{
			
				projectile.width = 60;   //This defines the hitbox width
				projectile.height = 45;    //This defines the hitbox height
				projectile.aiStyle = 16;  //How the projectile works, 16 is the aistyle Used for: Grenades, Dynamite, Bombs, Sticky Bomb.
				projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
			  projectile.damage = 0;
				projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed
				projectile.timeLeft = 120; //The amount of time the projectile is alive for
				
			}



			public override void Kill(int timeLeft)
			{

				Vector2 position = projectile.Center;
				Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
			  int radius = 3;     //this is the explosion radius, the highter is the value the bigger is the explosion

				for (int x = -radius; x <= radius; x++)
				{
					for (int y = -radius; y <= radius; y++)
					{
						int xPosition = (int)(x + position.X / 16.0f);
						int yPosition = (int)(y + position.Y / 16.0f);

						if (Math.Sqrt(x * x + y * y) <= radius + 0.5)   //this make so the explosion radius is a circle
						{
						
							//WorldGen.KillTile(xPosition, yPosition, false, false, false);  //this make the explosion destroy tiles  
							Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);  //this is the dust that will spawn after the explosion
						}
					}
				}
			}
