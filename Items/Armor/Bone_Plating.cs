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
    class Bone_Plating: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Plating");
            Tooltip.SetDefault("After taking damage, the next 3 instances of damage taken within 3 seconds will deal 40% less damage\nDoes not affect lethal damage\n12 second cooldown");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.accessory = true;
            item.value = 25000;
            item.rare = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().bonePlating = true;
        }
    }
}
