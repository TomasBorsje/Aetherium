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
    internal class Dead_Mans_Plate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dead Man's Plate");
            Tooltip.SetDefault("Increases defense by 3\nIncreases defense based on how fast you are moving");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = 25000;
            item.rare = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().deadMansPlate = true;
        }
    }
}
