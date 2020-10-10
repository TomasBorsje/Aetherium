using Aetherium.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Projectiles
{
	public class Skyshard_Arrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skyshard Arrow");
		}

		public override void SetDefaults()
		{
			projectile.arrow = true;
			projectile.width = 14;
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
			Lighting.AddLight(projectile.position, 0.26f, 0.52f, 0.95f);
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(projectile.position, 50, 50, ModContent.DustType<Puff>(), SpeedX: 0, SpeedY: 0, Alpha: 50);
			}
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			Vector2 dir = projectile.DirectionTo(Main.player[projectile.owner].position);
			dir.Normalize();
            projectile.velocity = dir*oldVelocity.Length();
			projectile.penetrate--;
			Main.PlaySound(SoundID.Dig, projectile.position);
			return false;
        }
        public override void Kill(int timeLeft)
        {
			for (int i = 0; i < 15; i++)
			{
				Dust.NewDust(projectile.position, 75, 75, ModContent.DustType<Puff>(), SpeedX: 0, SpeedY: 0, Alpha: 50);
			}
			Main.PlaySound(SoundID.Dig, projectile.position);
		}
    }
}