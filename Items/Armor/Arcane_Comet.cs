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
    class Arcane_Comet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arcane Comet");
            Tooltip.SetDefault("Dealing ranged damage fires a piercing arcane comet, dealing 150% of the attack's damage\n4 second cooldown");
        }
        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 30;
            item.accessory = true;
            item.value = 25000;
            item.rare = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().arcaneComet = true;
        }
    }
}
