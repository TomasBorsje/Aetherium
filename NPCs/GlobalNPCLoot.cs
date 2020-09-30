using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.NPCs
{
    public class GlobalNPCLoot : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if(npc.type == NPCID.SpikedJungleSlime)
            {
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Armor.Imbued_Seedling>());
                }
            }
            
        }
    }
}
