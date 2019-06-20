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
    internal class Flame_Lantern : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flame Lantern");
            Tooltip.SetDefault("Causes summon damage to set enemies alight\nIncreases your max number of minions\nIncreases minion damage by 7%");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 26;
            item.accessory = true;
            item.value = 25000;
            item.rare = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // To assign the player the frostBurnSummon effect, we can't do player.frostBurnSummon = true because Player doesn't have frostBurnSummon. Be sure to remember to call the GetModPlayer method to retrieve the ModPlayer instance attached to the specified Player.
            player.GetModPlayer<AetheriumModPlayer>().flameLantern = true;
            player.maxMinions += 1;
            player.minionDamage += 0.07f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Chain, 2);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe altrecipe = new ModRecipe(mod);
            altrecipe.AddIngredient(ItemID.Chain, 2);
            altrecipe.AddIngredient(ItemID.Wood, 10);
            altrecipe.AddIngredient(ItemID.LeadBar, 5);
            altrecipe.AddTile(TileID.Anvils);
            altrecipe.SetResult(this);
            altrecipe.AddRecipe();
        }
    }

}
