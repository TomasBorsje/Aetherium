using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Aetherium.Items.Armor;
using Aetherium.Items.Placeable;


namespace Aetherium
{
    public class AetheriumWorld : ModWorld
    {
        public static bool spawnViscera = false;
		const int WOODEN_CHEST = 0;
		const int GOLD_CHEST = 1;
		const int SKYWARE_CHEST = 13;
		const int AETHERIUM_ITEM_CHANCE = 7; // One in x items is an aetherium item
		public override void PostWorldGen()
		{
			int[] woodenChestItems = { ModContent.ItemType<Harumachi_Clover>() };
			int[] goldChestItems = { ModContent.ItemType<Wicked_Scythe>(), ModContent.ItemType<Mana_Leech>(), ModContent.ItemType<Soulcharger>() };
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
								chest.item[inventoryIndex].SetDefaults(ModContent.ItemType<Aether_Altar>());
								break;
							}
						}
					}
				}
			}
		}
	}
}