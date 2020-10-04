using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Aetherium.Items.Tiles
{
    public class Skyshard_Ore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skyshard Ore");
            Tooltip.SetDefault("Combine with blobs of aether at an aether altar");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.rare = ItemRarityID.Blue;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("Skyshard_Ore");
        }
    }
}