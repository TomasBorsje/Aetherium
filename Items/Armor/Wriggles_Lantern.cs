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
    internal class Wriggles_Lantern : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wriggle's Lantern");
            Tooltip.SetDefault("Causes summon damage to apply fire, frostfire, cursed inferno, and shadowfire\nIncreases your max number of minions\nIncreases minion damage by 20%");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 60;
            item.accessory = true;
            item.value = 250000;
            item.rare = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().heartOfFrost = true;
            player.GetModPlayer<AetheriumModPlayer>().flameLantern = true;
            player.GetModPlayer<AetheriumModPlayer>().cursedLantern = true;
            player.maxMinions += 3;
            player.minionDamage += 0.2f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Flame_Lantern"), 1);
            recipe.AddIngredient(mod.ItemType("Frost_Lantern"), 1);
            recipe.AddIngredient(mod.ItemType("Cursed_Lantern"), 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
