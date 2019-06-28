using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Items.Consumables
{
    public class Hourglass : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unstable Warp Bubble");
            Tooltip.SetDefault("Freezes you in time\nMassively increases your defense but you cannot do anything for some time\nGood for dodging attacks or preventing fall damage");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 99;
            item.rare = 4;
            item.useAnimation = 6;
            item.useTime = 6;
            item.useStyle = 3;
            item.UseSound = new Terraria.Audio.LegacySoundStyle(2, 122);
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<AetheriumModPlayer>().frozenInTime = true; 
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.AddIngredient(mod.ItemType<Crafting.Bar_Of_Aetherium>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();

            ModRecipe altrecipe = new ModRecipe(mod);
            altrecipe.AddIngredient(ItemID.LeadBar, 2);
            altrecipe.AddIngredient(mod.ItemType<Crafting.Bar_Of_Aetherium>(), 2);
            altrecipe.AddTile(TileID.Anvils);
            altrecipe.SetResult(this, 5);
            altrecipe.AddRecipe();
        }
    }
}
