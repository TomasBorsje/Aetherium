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
    class Essence_Of_Endurance : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of Endurance");
            Tooltip.SetDefault("Regenerate health passively\nThis healing is greatly increased while below 30% life\nAfter taking damage, the next 3 instances of damage taken within 3 seconds will deal 40% less damage\nDoes not affect lethal damage\n12 second cooldown\nEnemies are more likely to target you");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.accessory = true;
            item.value = 25000;
            item.rare = 3;
        }
        public override void UpdateEquip(Player player)
        {
            player.aggro += 350;
        }

        int healTimer;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().bonePlating = true;
            if (healTimer > 0) { healTimer--; }
            if(player.statLife < player.statLifeMax && healTimer == 0)
            {
                healTimer = player.statLife < player.statLifeMax * 0.3f ? 10 : 30;
                player.HealEffect(1);
                player.statLife += 1;
            }
            if (player.statLife < player.statLifeMax * 0.3f)
            {
                if (Main.rand.Next(6) == 0)
                {
                    Dust.NewDust(player.position, player.width, player.height, 44);
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Imbued_Seedling>());
            recipe.AddIngredient(ModContent.ItemType<Bone_Plating>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
