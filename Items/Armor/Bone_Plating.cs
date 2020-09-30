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
    class Bone_Plating: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Plating");
            Tooltip.SetDefault("After taking damage, the next 3 instances of damage taken within 3 seconds will deal 40% less damage\nDoes not affect lethal damage\n12 second cooldown\nEnemies are more likely to target you");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = 25000;
            item.rare = 3;
        }

        public override void UpdateEquip(Player player)
        {
            player.aggro += 350;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().bonePlating = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 15);
            recipe.AddIngredient(ItemID.Stinger, 7);
            recipe.AddIngredient(ItemID.JungleSpores, 12);
            recipe.AddIngredient(ItemID.Vine, 2);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
