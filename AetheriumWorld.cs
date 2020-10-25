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
using Terraria.ModLoader.IO;

namespace Aetherium
{
    public class AetheriumWorld : ModWorld
    {
		const int WOODEN_CHEST = 0;
		const int GOLD_CHEST = 1;
		const int SKYWARE_CHEST = 13;
		const int AETHERIUM_ITEM_CHANCE = 7; // One in x items is an aetherium item
		public static bool downedElementalSlimes;

		public override void Initialize()
		{
			downedElementalSlimes = false;
		}
		public override TagCompound Save()
		{
			var downed = new List<string>();
			if (downedElementalSlimes)
			{
				downed.Add("elementalSlimes");
			}

			return new TagCompound
			{
				["downed"] = downed,
			};
		}

		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			downedElementalSlimes = downed.Contains("elementalSlimes");
		}

		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				downedElementalSlimes = flags[0];
			}
			else
			{
				mod.Logger.WarnFormat("Aetherium: Unknown loadVersion: {0}", loadVersion);
			}
		}

		public override void NetSend(BinaryWriter writer)
		{
			var flags = new BitsByte();
			flags[0] = downedElementalSlimes;
			writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedElementalSlimes = flags[0];
		}

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