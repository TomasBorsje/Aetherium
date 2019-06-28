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
    public class Bar_Of_Viscera : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bar of Viscera");
            Tooltip.SetDefault("It's staring back at you..");

        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.value = 250;
            item.maxStack = 99;
            item.rare = 4;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Viscera_Block_Item"), 5);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class True_Aetherium_Bar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Aetherium Bar");
            Tooltip.SetDefault("Truly lighter than air");
            ItemID.Sets.ItemNoGravity[item.type] = true;

        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 28;
            item.value = 5000;
            item.maxStack = 99;
            item.rare = 9;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Bar_Of_Aetherium"), 1);
            recipe.AddIngredient(ItemID.PixieDust, 1);
            recipe.AddIngredient(ItemID.Cloud, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
