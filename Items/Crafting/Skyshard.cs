using Aetherium.Items.Tiles;
using Aetherium.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Items.Crafting
{
    class Skyshard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skyshard");
        }
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 26;
            item.maxStack = 999;
            item.value = 100;
            item.rare = ItemRarityID.Blue;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tiles.Skyshard_Ore>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Blob_Of_Aether>(), 2);
            recipe.AddTile(mod.TileType("Aether_Altar"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
