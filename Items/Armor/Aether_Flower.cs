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
    internal class Aether_Flower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aether Flower");
            Tooltip.SetDefault("Increases minion damage based on your current mana\n+10% minion damage per 200 mana");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.accessory = true;
            item.value = 25000;
            item.rare = 9;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Aetherium_Bar"), 15);
            recipe.AddIngredient(mod.ItemType("Blob_Of_Aetherium"), 25);
            recipe.AddIngredient(ItemID.Cloud, 25);
            recipe.AddIngredient(ItemID.NaturesGift);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.minionDamage += ((float)player.statMana/2000);
        }
    }

}
