using Aetherium.Items.Crafting;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Items.Consumables
{
    public class Aether_Wisp : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aether Wisp in a Bottle");
            Tooltip.SetDefault("Summons an Aether Wisp to follow you around\nThank you for downloading Aetherium!");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.width = 20;
            item.height = 30;
            item.shoot = mod.ProjectileType("Aether_Wisp");
            item.buffType = mod.BuffType("Aether_Wisp");
            item.rare = 9;
            item.value = 0;
            item.UseSound = new Terraria.Audio.LegacySoundStyle(2, 25);
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ModContent.ItemType<Blob_Of_Aether>(), 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AetheriumModPlayer>().aetherWisp = true;
        }
    }
}