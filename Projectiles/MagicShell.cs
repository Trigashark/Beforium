
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Beforium.Projectiles
{
	public class MagicShell : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MagicShell");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.width = 6;
			projectile.height = 12;
			projectile.aiStyle = 24;
			projectile.magic = true;
			projectile.friendly = true;
			projectile.timeLeft = 200;

			projectile.penetrate = -1;
		}

		public override bool PreAI()
		{
			if (projectile.ai[0] == 0)
				projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			else
			{
				projectile.ignoreWater = true;
				projectile.tileCollide = false;
				int num996 = 15;
				bool flag52 = false;
				bool flag53 = false;
				projectile.localAI[0] += 1f;
				if (projectile.localAI[0] % 30f == 0f)
					flag53 = true;

				int num997 = (int)projectile.ai[1];
				if (projectile.localAI[0] >= (float)(60 * num996))
					flag52 = true;
				else if (num997 < 0 || num997 >= 200)
					flag52 = true;
				else if (Main.npc[num997].active && !Main.npc[num997].dontTakeDamage)
				{
					projectile.Center = Main.npc[num997].Center - projectile.velocity * 2f;
					projectile.gfxOffY = Main.npc[num997].gfxOffY;
					if (flag53)
					{
						Main.npc[num997].HitEffect(0, 1.0);
					}
				}
				else
					flag52 = true;

				if (flag52)
					projectile.Kill();
			}

			projectile.frameCounter++;
			if (projectile.frameCounter >= 4)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
				if (projectile.frame >= 4)
					projectile.frame = 0;
			}
			return false;
		}

		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
		}

	}
}