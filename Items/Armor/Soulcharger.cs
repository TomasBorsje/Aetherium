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
    class Soulcharger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soulcharger");
            Tooltip.SetDefault("Killing an enemy increases your max mana by 20\nThis effect is lost after 10 seconds of no combat\nMax 100 bonus mana\n'Any sufficiently advanced technology is indistinguishable from magic'");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 32;
            item.accessory = true;
            item.value = 25000;
            item.rare = 3;
        }

        int healTimer;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().prescenceOfMind = true;
        }
    }
}
