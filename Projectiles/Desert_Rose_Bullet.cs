using Aetherium.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Projectiles
{
	public class Desert_Rose_Bullet: ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Rose Bullet");
			
		}

		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 16;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 999;
			projectile.timeLeft = 12;
			aiType = ProjectileID.Bullet;
		}

        public override void AI()
        {
            if(Main.rand.NextBool(6))
            {
				Dust.NewDust(projectile.position, 5, 5, DustID.Sandnado, projectile.velocity.X/10f, projectile.velocity.Y/10f);
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			Main.PlaySound(new LegacySoundStyle(2, 10), projectile.position);
			return true;
        }
    }
}