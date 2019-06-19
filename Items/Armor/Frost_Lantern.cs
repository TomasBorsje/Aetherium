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
    internal class Frost_Lantern : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Lantern");
            Tooltip.SetDefault("Causes summon damage to apply frostburn for a time depending on damage dealt\nIncreases your max number of minions\nIncreases minion damage by 8%");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 26;
            item.accessory = true;
            item.value = 25000;
            item.rare = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().heartOfFrost = true;
            player.maxMinions += 1;
            player.minionDamage += 0.04f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HeartLantern, 1);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddIngredient(ItemID.IceBlock, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
