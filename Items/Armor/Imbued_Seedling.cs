using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Items.Armor
{
    class Imbued_Seedling : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Imbued Seedling");
            Tooltip.SetDefault("Regenerate health passively\nThis healing is greatly increased while below 30% life");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 30;
            item.accessory = true;
            item.value = 25000;
            item.rare = 3;
        }

        int healTimer;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (healTimer > 0) { healTimer--; }
            if(player.statLife < player.statLifeMax && healTimer == 0)
            {
                healTimer = player.statLife < player.statLifeMax * 0.3f ? 10 : 30;
                player.HealEffect(1);
                player.statLife += 1;
            }
            if (player.statLife < player.statLifeMax * 0.3f)
            {
                if (Main.rand.Next(5) == 0)
                {
                    Dust.NewDust(player.position, player.width, player.height, 44);
                }
            }
        }
    }
}
