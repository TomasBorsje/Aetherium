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
    class Fury_Of_The_Storm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Cloud in a Bottle");
            Tooltip.SetDefault("Rapidly striking the same enemy 3 times will shock them, echoing the damage\n5 second cooldown");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.accessory = true;
            item.value = 25000;
            item.rare = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().furyOfTheStorm = true;
        }
    }
}
