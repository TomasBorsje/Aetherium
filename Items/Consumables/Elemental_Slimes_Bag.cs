using Aetherium.Items.Crafting;
using Aetherium.Items.Weapons;
using Aetherium.Items.Armor;
using Aetherium.NPCs.Bosses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Items.Consumables
{
    public class Elemental_Slimes_Bag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.rare = ItemRarityID.Expert;
            item.expert = true;
        }
		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
            player.QuickSpawnItem(ModContent.ItemType<Catalyst_Of_Aeons>()); // Every bag has a catalyst
            int[] items = { ModContent.ItemType<Desert_Rose>(), ModContent.ItemType<Ice_Staff>(), ModContent.ItemType<Molten_Edge>(), ModContent.ItemType<Bee_Swarm_Staff>() };
            int choice1 = Main.rand.Next(items);
            player.QuickSpawnItem(choice1);
            int choice2 = Main.rand.Next(items);
            while (choice2 == choice1)
            {
                choice2 = Main.rand.Next(items);
            }
            player.QuickSpawnItem(choice2);
        }
		public override int BossBagNPC => ModContent.NPCType<Fire_Slime>();
	}
}