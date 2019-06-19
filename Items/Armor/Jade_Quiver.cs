using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Aetherium.Items.Armor
{
    internal class Jade_Quiver : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jade Quiver");
            Tooltip.SetDefault("Consuming ammo restores a small amount of health\nDealing critical damage with an arrow heals for a larger amount\nIncreases ranged damage by 4%");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = 25000;
            item.rare = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().jadeQuiver = true;
            player.rangedDamage += 0.04f;
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
