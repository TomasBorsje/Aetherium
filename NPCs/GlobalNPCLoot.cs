using Aetherium.Items.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.NPCs
{
    public class GlobalNPCLoot : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.damage > 1 && npc.lifeMax > 1)
            {
                if (npc.type == NPCID.SpikedJungleSlime)
                {
                    if (Main.rand.Next(50) == 0)
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Armor.Imbued_Seedling>());
                    }
                }
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    npc.DropItemInstanced(npc.position, npc.Size, ModContent.ItemType<Items.Armor.Warped_Locket>(), 1, true);
                }
                if (npc.type == NPCID.WallofFlesh)
                {
                    npc.DropItemInstanced(npc.position, npc.Size, ModContent.ItemType<Items.Armor.Voidtouched_Heart>(), 1, true);
                }
                if (Main.hardMode)
                {
                    if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUndergroundDesert)
                    {
                        if (Main.rand.NextBool(250))
                        {
                            Item.NewItem(npc.getRect(), ModContent.ItemType<Desert_Rose>());
                        }
                    }
                }
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.ArmsDealer)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Desert_Rose>());
                nextSlot++;
            }
        }
    }
}
