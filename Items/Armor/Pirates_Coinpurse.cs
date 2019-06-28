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
    internal class Pirates_Coinpurse : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pirate's Coinpurse");
            Tooltip.SetDefault("Every tenth enemy killed drops bonus money");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.accessory = true;
            item.value = 25000;
            item.rare = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().theCulling = true;
        }
    }

}
