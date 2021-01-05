public class DEATH : ModProjectile
		{
			public override void SetStaticDefaults()
			{

				DisplayName.SetDefault("DEATH");

			}
			public override void SetDefaults()
			{
				projectile.damage = 10000;
				projectile.friendly = true;
				projectile.ranged = true;
				projectile.width = 14;
				projectile.height = 32;
				projectile.aiStyle = 1;
				projectile.penetrate = 1000;
				projectile.arrow = true;

			}
			public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
			{

				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.projectileType("DEATH"), 100, 0, projectile.whoAmI);
			//say goodbye to your PC
			}


		}
