using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Aetherium.Projectiles
{
    public class Rail : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 2;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 6;
            projectile.timeLeft = 180;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Main.rand.Next(4) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 15);
            }
        }

       // public override bool OnTileCollide(Vector2 oldVelocity)
       // {

       // }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(new Terraria.Audio.LegacySoundStyle(2, 10), projectile.position);
            Dust.NewDust(projectile.position, projectile.width, projectile.height, 15);

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
           // Main.PlaySound(new Terraria.Audio.LegacySoundStyle(2, 14), projectile.position);
        }

    }
}
