using Aetherium.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Projectiles
{
	public class Chromatic_Bullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chromatic Bullet");
			//projectile.CloneDefaults(ProjectileID.ChlorophyteBullet);
		}

		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.maxPenetrate = 1;
			projectile.timeLeft = 300;
			aiType = ProjectileID.Bullet;
		}

        public override void AI()
        {
			Dust.NewDust(projectile.position, projectile.width, projectile.height, Main.rand.Next(59, 66), projectile.velocity.X / 10f, projectile.velocity.Y / 10f);
			float num166 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
			float num167 = projectile.localAI[0];
			if (num167 == 0f)
			{
				projectile.localAI[0] = num166;
				num167 = num166;
			}
			if (projectile.alpha > 0)
			{
				projectile.alpha -= 25;
			}
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			float num168 = projectile.position.X;
			float num169 = projectile.position.Y;
			float num170 = 300f;
			bool flag4 = false;
			int num171 = 0;
			if (projectile.ai[1] == 0f)
			{
				for (int num172 = 0; num172 < 200; num172++)
				{
					if (Main.npc[num172].CanBeChasedBy(this) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num172 + 1)))
					{
						float num173 = Main.npc[num172].position.X + (float)(Main.npc[num172].width / 2);
						float num174 = Main.npc[num172].position.Y + (float)(Main.npc[num172].height / 2);
						float num175 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num173) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num174);
						if (num175 < num170 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[num172].position, Main.npc[num172].width, Main.npc[num172].height))
						{
							num170 = num175;
							num168 = num173;
							num169 = num174;
							flag4 = true;
							num171 = num172;
						}
					}
				}
				if (flag4)
				{
					projectile.ai[1] = num171 + 1;
				}
				flag4 = false;
			}
			if (projectile.ai[1] > 0f)
			{
				int num176 = (int)(projectile.ai[1] - 1f);
				if (Main.npc[num176].active && Main.npc[num176].CanBeChasedBy(this, ignoreDontTakeDamage: true) && !Main.npc[num176].dontTakeDamage)
				{
					float num177 = Main.npc[num176].position.X + (float)(Main.npc[num176].width / 2);
					float num178 = Main.npc[num176].position.Y + (float)(Main.npc[num176].height / 2);
					if (Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num177) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num178) < 1000f)
					{
						flag4 = true;
						num168 = Main.npc[num176].position.X + (float)(Main.npc[num176].width / 2);
						num169 = Main.npc[num176].position.Y + (float)(Main.npc[num176].height / 2);
					}
				}
				else
				{
					projectile.ai[1] = 0f;
				}
			}
			if (!projectile.friendly)
			{
				flag4 = false;
			}
			if (flag4)
			{
				float num179 = num167;
				Vector2 vector9 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float num180 = num168 - vector9.X;
				float num181 = num169 - vector9.Y;
				float num182 = (float)Math.Sqrt(num180 * num180 + num181 * num181);
				num182 = num179 / num182;
				num180 *= num182;
				num181 *= num182;
				int num183 = 8;
				projectile.velocity.X = (projectile.velocity.X * (float)(num183 - 1) + num180) / (float)num183;
				projectile.velocity.Y = (projectile.velocity.Y * (float)(num183 - 1) + num181) / (float)num183;
			}
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			Main.PlaySound(new LegacySoundStyle(2, 10), projectile.Center);
			return true;
        }
    }
}