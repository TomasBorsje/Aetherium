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
    internal class Cursed_Lantern : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Lantern");
            Tooltip.SetDefault("Causes summon damage to burn enemies with cursed fire if they are alight with both frost and normal fire\nIncreases your max number of minions\nIncreases minion damage by 10%");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 26;
            item.accessory = true;
            item.value = 25000;
            item.rare = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().cursedLantern = true;
            player.maxMinions += 1;
            player.minionDamage += 0.1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Chain, 2);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddIngredient(mod.ItemType("Bar_Of_Aetherium"), 7);
            recipe.AddIngredient(ItemID.ShadowOrb, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe altrecipe = new ModRecipe(mod);
            altrecipe.AddIngredient(ItemID.Chain, 2);
            altrecipe.AddIngredient(ItemID.Wood, 10);
            altrecipe.AddIngredient(ItemID.LeadBar, 5);
            altrecipe.AddIngredient(mod.ItemType("Bar_Of_Aetherium"), 7);
            altrecipe.AddIngredient(ItemID.CrimsonHeart, 1);
            altrecipe.AddTile(TileID.Anvils);
            altrecipe.SetResult(this);
            altrecipe.AddRecipe();
        }
    }

}
