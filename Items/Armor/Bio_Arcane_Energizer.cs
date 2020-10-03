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
    class Bio_Arcane_Energizer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bio-Arcane Energizer");
            Tooltip.SetDefault("Killing an enemy increases your max mana and restores 30% of your missing mana\nBonus mana lasts for 10 seconds out of combat\nMax 100 bonus mana\n'Any sufficiently advanced technology is indistinguishable from magic'");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 30;
            item.accessory = true;
            item.value = 50000;
            item.rare = 3;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().manaLeech = true;
            player.GetModPlayer<AetheriumModPlayer>().prescenceOfMind = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Soulcharger>());
            recipe.AddIngredient(ModContent.ItemType<Mana_Leech>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
