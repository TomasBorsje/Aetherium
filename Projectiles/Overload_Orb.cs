using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Aetherium.Projectiles
{
    public class Overload_Orb : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Hook);
            projectile.width = 16;
            projectile.height = 16;
            //projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 99;
            projectile.maxPenetrate = 99;
            //projectile.timeLeft = 600;
        }

        public override void AI()
        {
        //    projectile.velocity.Y += projectile.ai[0];
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.life = 1;
            projectile.velocity *= 1.25f;
        }

    }
}
