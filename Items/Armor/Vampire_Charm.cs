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
    internal class Vampire_Charm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampire Charm");
            Tooltip.SetDefault("Dealing damage stores 5% of the damage dealt as charge\nTaking damage consumes all stored charge to heal you, up to 50\nDoes not prevent fatal damage");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.accessory = true;
            item.value = 25000;
            item.rare = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().vampireCharm = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 15);
            recipe.AddIngredient(ItemID.Emerald, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}
