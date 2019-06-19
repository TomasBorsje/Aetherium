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
    internal class Guardians_Resolve : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guardian's Resolve");
            Tooltip.SetDefault("Increases defense by 2\nIncreases defense by 0.5 for each town NPC you have");
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
            player.GetModPlayer<AetheriumModPlayer>().guardiansCourage = true;
        }
    }
}
