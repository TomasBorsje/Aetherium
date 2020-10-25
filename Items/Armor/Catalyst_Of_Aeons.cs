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
    class Catalyst_Of_Aeons : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Catalyst of Aeons");
            Tooltip.SetDefault("Taking damage grants mana\nUsing mana grants health");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 24;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Expert;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().catalystOfAeons = true;
        }
    }
}
