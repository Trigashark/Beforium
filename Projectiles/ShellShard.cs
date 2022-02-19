
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Beforium.Dusts;
using Terraria.ModLoader;

namespace Beforium.Projectiles
{
	public class ShellShard : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ShellShard");
		}
		public override void SetDefaults()
		{
			projectile.width = 9;
			projectile.damage = 20;
			projectile.height = 18;
			projectile.penetrate = 2;
			projectile.aiStyle = 3;
			aiType = ProjectileID.WoodenArrowFriendly;
			projectile.ranged = true;
			projectile.friendly = true;
			projectile.light = 0.5f;
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
			for (int i = 0; i < 2; i++)
			{
			}
		}
        public override void AI()
        {
			if (projectile.alpha <= 100)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Pixel>());
				Main.dust[dust].velocity /= 2f;
			}
		}
    }
}