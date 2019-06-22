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
    internal class Mana_Leech : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mana Leech");
            Tooltip.SetDefault("Dealing non-minion damage can consume 30 mana to deal an additional 20 damage");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 24;
            item.accessory = true;
            item.value = 25000;
            item.rare = 9;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Aetherium_Bar"), 9);
            recipe.AddIngredient(mod.ItemType("Blob_Of_Aetherium"), 20);
            recipe.AddIngredient(ItemID.TruffleWorm, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().mana_consume = true;
        }
    }

}
