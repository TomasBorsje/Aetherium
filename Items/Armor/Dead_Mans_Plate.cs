using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader;
using Aetherium.Items.Crafting;

namespace Aetherium.Items.Armor
{
    class Dead_Mans_Plate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dead Man's Plate");
            Tooltip.SetDefault("Increases defense by 3\nGain defense based on how fast you are moving\nEnemies are more likely to target you");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 28;
            item.accessory = true;
            item.value = 25000;
            item.defense = 3;
            item.rare = ItemRarityID.Green;
        }
        public override void UpdateEquip(Player player)
        {
            player.statDefense += (int)(player.velocity.Length() * 0.75f);
            player.aggro += 400;
        }
    }
}
