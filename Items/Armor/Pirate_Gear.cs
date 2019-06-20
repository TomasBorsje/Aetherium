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
    internal class Pirate_Gear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pirate Gear");
            Tooltip.SetDefault("Increases defense by 3\nIncreases defense based on how fast you are moving\nEvery tenth enemy killed drops bonus money\nIncreases max health by 15");
        }
        public override void SetDefaults()
        {
            item.width = 58;
            item.height = 50;
            item.accessory = true;
            item.value = 100000;
            item.rare = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().theCulling = true;
            player.GetModPlayer<AetheriumModPlayer>().deadMansPlate = true;
            player.GetModPlayer<AetheriumModPlayer>().pirateHealthBuff = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Pirates_Coinpurse"), 1);
            recipe.AddIngredient(mod.ItemType("Dead_Mans_Plate"), 1);
            recipe.AddIngredient(ItemID.GoldBar, 3);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
