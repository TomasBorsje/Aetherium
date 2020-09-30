using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Projectiles
{
	public class Sakura_Petal : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sakura Petal");
		}

		public override void SetDefaults()
		{
			projectile.arrow = true;
			projectile.width = 16;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 2;
			projectile.timeLeft = 120;
			aiType = ProjectileID.WoodenArrowFriendly;
		}

		public override void AI()
        {
			Lighting.AddLight(projectile.position, 1f, 0.7f, 7.5f);
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(projectile.position, 50, 50, 255, SpeedX: 0, SpeedY: 0, Alpha: 50);
			}
		}
        public override void Kill(int timeLeft)
        {
			for (int i = 0; i < 15; i++)
			{
				Dust.NewDust(projectile.position, 75, 75, 255, SpeedX: 0, SpeedY: 0, Alpha: 50);
			}
			Main.PlaySound(6, projectile.position);
		}
    }
}