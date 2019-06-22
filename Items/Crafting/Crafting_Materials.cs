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
    public class Blob_Of_Aetherium : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blob of Aetherium");
            Tooltip.SetDefault("Light and wispy\nCombine 5 at a cloud block");
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 2500;
            item.maxStack = 999;
            item.rare = 9;
        }
    }
    public class Bar_Of_Aetherium : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aetherium Bar");
            Tooltip.SetDefault("Almost lighter than air");
            ItemID.Sets.ItemNoGravity[item.type] = true;

        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 2500;
            item.maxStack = 99;
            item.rare = 9;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Blob_Of_Aetherium"), 5);
            recipe.AddTile(TileID.Cloud);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
