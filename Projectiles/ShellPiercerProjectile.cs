using Microsoft.Xna.Framework;
using Terraria;
using Beforium.Dusts;
using Terraria.ModLoader;

namespace Beforium.Projectiles
{
    public class ShellPiercerProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ShellPiercer");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
		public float movementFactor 
		{
			get => projectile.ai[0];
			set => projectile.ai[0] = value;
		}
		public override void AI()
		{
			if (projectile.alpha <= 100)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Pixel>());
				Main.dust[dust].velocity /= 2f;
			}
			Player projOwner = Main.player[projectile.owner];
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			projectile.direction = projOwner.direction;
			projOwner.heldProj = projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
			projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
			if (!projOwner.frozen)
			{
				if (movementFactor == 0f) 
				{
					movementFactor = 3f; 
					projectile.netUpdate = true; 
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 1.8) 
				{
					movementFactor -= 1f;
				}
				else 
				{
					movementFactor += 1.4f;
				}
			}
			projectile.position += projectile.velocity * movementFactor;
			if (projOwner.itemAnimation == 0)
			{
				projectile.Kill();
			}
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= MathHelper.ToRadians(90f);
			}
			if (Main.rand.NextBool(3))
			{
			}
			if (Main.rand.NextBool(4))
			{
			}
		}
	}
}