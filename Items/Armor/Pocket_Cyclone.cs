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
    internal class Pocket_Cyclone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pocket Cyclone");
            Tooltip.SetDefault("Enemies that damage you increase your speed and are flung into the air");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 28;
            item.accessory = true;
            item.value = 25000;
            item.rare = 9;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().pocketCyclone = true;
            
        }
    }

}
