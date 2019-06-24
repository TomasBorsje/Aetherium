using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Projectiles.Pets
{
    public class Aether_Wisp : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aether Wisp");
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ZephyrFish);
            aiType = ProjectileID.ZephyrFish;
            
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            player.zephyrfish = false;
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            AetheriumModPlayer modPlayer = player.GetModPlayer<AetheriumModPlayer>();
            if (player.dead)
            {
                modPlayer.aetherWisp = false;
            }
            if (modPlayer.aetherWisp)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}