using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Projectiles
{
	public class Arcane_Comet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arcane Comet");
		}

		public override void SetDefaults()
		{
			projectile.arrow = true;
			projectile.width = 18;
			projectile.height = 36;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 999;
			aiType = ProjectileID.WoodenArrowFriendly;
		}

		public override void AI()
        {
			Lighting.AddLight(projectile.position, 0f, 0.6f, 1f);
			Dust.NewDust(projectile.position, 50, 50, mod.DustType("Puff"), SpeedX: 0, SpeedY: 0, Alpha: 50);
		}
        public override void Kill(int timeLeft)
        {
			for (int i = 0; i < 50; i++)
			{
				Dust.NewDust(projectile.position, 75, 75, mod.DustType("Puff"), SpeedX: 0, SpeedY: 0, Alpha: 50);
			}
			Main.PlaySound(new Terraria.Audio.LegacySoundStyle(2, 118), projectile.position);
		}
    }
}