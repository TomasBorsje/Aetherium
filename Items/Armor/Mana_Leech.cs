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
    class Mana_Leech : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mana Leech");
            Tooltip.SetDefault("Killing an enemy restores 40% of your missing mana");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.accessory = true;
            item.value = 25000;
            item.rare = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().manaLeech = true;
        }
    }
}
