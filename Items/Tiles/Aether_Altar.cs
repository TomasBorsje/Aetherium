using Aetherium.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Aetherium.Items.Tiles
{
	public class Aether_Altar: ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aether Altar");
			Tooltip.SetDefault("Used to craft basic Aether related items\nFunctions as a workbench");
		}

		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 32;
			item.useTurn = true;
			item.autoReuse = true;
			item.rare = ItemRarityID.Cyan;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 1;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 20000;
			item.createTile = mod.TileType("Aether_Altar");
		}
	}
}