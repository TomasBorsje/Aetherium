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
    internal class Unobtanium : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unobtanium");
            Tooltip.SetDefault("Increases minion damage based on your current mana\n+10% minion damage per 200 mana");
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
            player.minionDamage += ((float)player.statMana/2000);
        }
    }

}
