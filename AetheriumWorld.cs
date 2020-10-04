using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Aetherium.Items.Armor;
using Aetherium.Items.Tiles;
using Aetherium.Tiles;

namespace Aetherium
{
    public class AetheriumWorld : ModWorld
    {
		const int WOODEN_CHEST = 0;
		const int GOLD_CHEST = 1;
		const int SKYWARE_CHEST = 13;
		const int AETHERIUM_ITEM_CHANCE = 7; // One in x items is an aetherium item
		public override void PostWorldGen()
		{
			int[] woodenChestItems = { ModContent.ItemType<Harumachi_Clover>(), ModContent.ItemType<Dead_Mans_Plate>() };
			int[] goldChestItems = { ModContent.ItemType<Wicked_Scythe>(), ModContent.ItemType<Mana_Leech>(), ModContent.ItemType<Soulcharger>() };

            for (int x = 0; x < Main.maxTilesX; x++)
            {
                for (int y = 0; y < Main.maxTilesY; y++)
                {
                    if (Main.tile[x, y] != null && Main.tile[x, y].type == TileID.Cloud)
                    {
                        if (Main.rand.NextBool(4))
                        {
                            Main.tile[x, y].type = (ushort)ModContent.TileType<Tiles.Skyshard_Ore>();
                        }
                    }
                }
            }

            //for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-02); k++)
            //{
            //	int x = WorldGen.genRand.Next(0, Main.maxTilesX);
            //	int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

            //	Tile tile = Framing.GetTileSafely(x, y);
            //	if (tile.active() && tile.type == TileID.Cloud)
            //	{
            //		WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<Tiles.Skyshard_Ore>());
            //	}
            //         }

            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
			Chest chest = Main.chest[chestIndex];

				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers) // Is it a chest?
				{
					if (Main.rand.NextBool(AETHERIUM_ITEM_CHANCE)) // One in 6 chance of an Aetherium item replacing the chest's main item
					{
						if (Main.tile[chest.x, chest.y].frameX == WOODEN_CHEST * 36) // Wooden chest
						{
							chest.item[0].SetDefaults(Main.rand.Next(woodenChestItems));
						}
						else if (Main.tile[chest.x, chest.y].frameX == GOLD_CHEST * 36) // Gold Chest
						{
							chest.item[0].SetDefaults(Main.rand.Next(goldChestItems));
						}
					}

					if (Main.tile[chest.x, chest.y].frameX == SKYWARE_CHEST * 36) // Add an aether altar to every skyware chest
					{
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
						{
							if (chest.item[inventoryIndex].type == ItemID.None)
							{
								chest.item[inventoryIndex].SetDefaults(ModContent.ItemType<Items.Tiles.Aether_Altar>());
								break;
							}
						}
					}
				}
			}
		}
	}
}