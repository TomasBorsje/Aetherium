using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Aetherium
{
    public class GlobalNpcLoot : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.damage > 1 && npc.lifeMax > 1) 
            {
                // Add loot here
            }
        }
    }
}
