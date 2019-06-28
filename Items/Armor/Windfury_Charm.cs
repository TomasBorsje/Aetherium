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
    internal class Windfury_Charm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Windfury Charm");
            Tooltip.SetDefault("Your attacks have a small chance to deal damage twice");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.accessory = true;
            item.value = 25000;
            item.rare = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().windfury = true;
        }
    }

}
