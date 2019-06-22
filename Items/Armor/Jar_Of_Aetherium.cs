using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Aetherium.Items.Armor
{
    internal class Jar_Of_Aetherium : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jar of Aetherium [WIP]");
            Tooltip.SetDefault("Activates when falling, slowing your fall for a few seconds\nRecharges when you touch the ground");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.accessory = true;
            item.value = 250000;
            item.rare = 9;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().jarOfAetherium = true;
        }
    }
}
