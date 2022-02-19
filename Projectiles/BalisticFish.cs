using System;
//using Beforium.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Beforium.Projectiles
{
    public class BalisticFish : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.friendly = true;
			projectile.light = 0.8f;
			projectile.magic = false;
			drawOriginOffsetY = -6;
		}

		

		public override void AI()
		{
			// effect sound
			if (projectile.soundDelay == 0 && Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) > 2f)
			{
				projectile.soundDelay = 10;
				Main.PlaySound(SoundID.Item13, projectile.position);
			}

		

			
			if (Main.myPlayer == projectile.owner && projectile.ai[0] == 0f)
			{

				Player player = Main.player[projectile.owner];
				
				if (player.channel)
				{
					float maxDistance = 18f; // speed follow
					Vector2 vectorToCursor = Main.MouseWorld - projectile.Center;
					float distanceToCursor = vectorToCursor.Length();

					
					if (distanceToCursor > maxDistance)
					{
						distanceToCursor = maxDistance / distanceToCursor;
						vectorToCursor *= distanceToCursor;
					}

					int velocityXBy1000 = (int)(vectorToCursor.X * 1000f);
					int oldVelocityXBy1000 = (int)(projectile.velocity.X * 1000f);
					int velocityYBy1000 = (int)(vectorToCursor.Y * 1000f);
					int oldVelocityYBy1000 = (int)(projectile.velocity.Y * 1000f);

					
					
					if (velocityXBy1000 != oldVelocityXBy1000 || velocityYBy1000 != oldVelocityYBy1000)
					{
						projectile.netUpdate = true;
					}

					projectile.velocity = vectorToCursor;

				}
				
				else if (projectile.ai[0] == 0f)
				{

					
					projectile.netUpdate = true;

					float maxDistance = 14f; //speed
					Vector2 vectorToCursor = Main.MouseWorld - projectile.Center;
					float distanceToCursor = vectorToCursor.Length();

					
					if (distanceToCursor == 0f)
					{
						vectorToCursor = projectile.Center - player.Center;
						distanceToCursor = vectorToCursor.Length();
					}

					distanceToCursor = maxDistance / distanceToCursor;
					vectorToCursor *= distanceToCursor;

					projectile.velocity = vectorToCursor;

					if (projectile.velocity == Vector2.Zero)
					{
						projectile.Kill();
					}

					projectile.ai[0] = 1f;
				}
			}

			
			if (projectile.velocity != Vector2.Zero)
			{
				projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver4;
			}
		}

		public override void Kill(int timeLeft)
		{
			//explosion 
			if (projectile.penetrate == 1)
			{

				
				projectile.maxPenetrate = -1;
				projectile.penetrate = -1;

				Main.screenPosition += Utils.RandomVector2(Main.rand, Main.rand.Next(-199, 200), Main.rand.Next(-199, 200));
				int explosionArea = 60;
				Vector2 oldSize = projectile.Size;
				
				projectile.position = projectile.Center;
				projectile.Size += new Vector2(explosionArea);
				projectile.Center = projectile.position;

				projectile.tileCollide = false;
				projectile.velocity *= 0.01f;
				
				projectile.Damage();
				projectile.scale = 0.01f;

				
				projectile.position = projectile.Center;
				projectile.Size = new Vector2(10);
				projectile.Center = projectile.position;
			}

			Main.PlaySound(SoundID.Item14, projectile.position);
			for (int i = 0; i < 10; i++)
			{
                
			}
		}

	}
}