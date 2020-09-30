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
    class Wicked_Scythe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wicked Scythe");
            Tooltip.SetDefault("Your attacks deal an additional 15% damage to enemies under 50% hp");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 38;
            item.accessory = true;
            item.value = 25000;
            item.rare = 3;
        }

        int healTimer;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().wickedScythe = true;
        }
    }
}
