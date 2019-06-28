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
    public class Aetherium_Staff_Bolt : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 180;

        }
        bool hasReturned = false;
        public override void AI()
        {
            projectile.ai[0]++;
            if (Main.rand.Next(4) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.BubbleBlock);
            }
            if (Main.myPlayer == projectile.owner)
            {
                projectile.netUpdate = true;
                if (projectile.ai[0] < 90)
                {
                    Vector2 direction = (Main.MouseWorld - projectile.position);
                    direction.Normalize();
                    projectile.velocity = direction * 7.5f;
                }
                else if (hasReturned)

                {
                    Vector2 direction = (Main.player[projectile.owner].position - projectile.position);
                    direction.Normalize();
                    projectile.velocity = direction * 7.5f;
                }
                else
                {

                    for (int i = 0; i < 6; i++)
                    {
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.BubbleBlock);
                    }
                    Main.PlaySound(SoundID.Drip, projectile.position);
                    hasReturned = true;
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate--;
            if (projectile.penetrate < 1)
            {
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                Main.PlaySound(SoundID.Splash, projectile.position);
                projectile.velocity *= 1.2f;
                
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.BubbleBlock, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            
        }

    }
}
