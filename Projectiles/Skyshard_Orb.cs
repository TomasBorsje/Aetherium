using Aetherium.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Aetherium.Projectiles
{
	public class Skyshard_Orb : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 600;
		}

		public override void AI()
		{
			projectile.ai[0]++;
			if(projectile.ai[0] > 120)
            {
				projectile.velocity = projectile.DirectionTo(Main.player[projectile.owner].position) * ((projectile.ai[0] - 120) / 30f);
			}
			if(projectile.Distance(Main.player[projectile.owner].position) < 32 && projectile.ai[0] > 120)
            {
				projectile.Kill();
            }
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<Puff>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
	}
}