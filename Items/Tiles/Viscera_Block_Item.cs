using Terraria;
using Terraria.ID;
// If you are using c# 6, you can use: "using static Terraria.Localization.GameCulture;" which would mean you could just write "DisplayName.AddTranslation(German, "");"
using Terraria.Localization;
using Terraria.ModLoader;

namespace Aetherium.Items.Tiles
{
    public class Viscera_Block_Item: ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A heap of garbled flesh and bones");
            DisplayName.SetDefault("Viscera");
        }

        public override void SetDefaults()
        {
            item.width = 23;
            item.height = 25;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.rare = 4;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("Viscera_Block");
        }
    }
}