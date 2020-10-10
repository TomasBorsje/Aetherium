using Microsoft.Xna.Framework;
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
    class Warped_Locket : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warped Locket");
            Tooltip.SetDefault("Your attacks may instantly kill lesser creatures");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 38;
            item.accessory = true;
            item.value = 25000;
            item.rare = 3;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips[0].overrideColor = Color.Purple;
            tooltips[1].text = "Equippable...?";
            tooltips[1].overrideColor = Color.MediumPurple;
            tooltips.Add(new TooltipLine(mod, "Warp1", "+50 warp")
            {
                overrideColor = Color.MediumPurple
            });
            tooltips.Add(new TooltipLine(mod, "Warp2", "Receive debuffs randomly, frequency and effect scaling with your warp level")
            {
                overrideColor = Color.MediumPurple
            });
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().warpedLocket = true;
            player.GetModPlayer<AetheriumModPlayer>().warp += 50;
            if(hideVisual)
            {
                player.ManaEffect(player.GetModPlayer<AetheriumModPlayer>().warp);
            }
        }
    }
}
