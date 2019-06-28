using Terraria;
using Terraria.ModLoader;

namespace Aetherium.Buffs
{
    public class Aether_Wisp : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Aether Wisp");
            Description.SetDefault("\"It yearns for the skies\"");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<AetheriumModPlayer>().aetherWisp = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("Aether_Wisp")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Aether_Wisp"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}