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
    public class Heavenly_Whisper_Bolt : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 15;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 180;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            projectile.spriteDirection = projectile.direction;
            projectile.velocity.Y += 0.04f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.BubbleBlock, projectile.oldVelocity.X * 0.05f, projectile.oldVelocity.Y * 0.05f);
        }

       // public override bool OnTileCollide(Vector2 oldVelocity)
       // {

       // }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 7; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.BubbleBlock, Main.rand.Next(-5,5), Main.rand.Next(-5, 5));
            }
            Main.PlaySound(new Terraria.Audio.LegacySoundStyle(2, 14), projectile.position);
            
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.BubbleBlock, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
            Main.PlaySound(new Terraria.Audio.LegacySoundStyle(2, 14), projectile.position);
        }

    }
}
