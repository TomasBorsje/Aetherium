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
    internal class True_Unobtanium : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Unobtanium");
            Tooltip.SetDefault("Dealing non-minion damage can consume 30 mana to deal an additional 20 damage");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = 2500000;
            item.rare = -12;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().mana_consume = true;
        }
    }

}
