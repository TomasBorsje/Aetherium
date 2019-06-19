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
            if (npc.position.Y > Main.worldSurface && npc.position.Y < Main.worldSurface * 0.35)
            {
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("Jade_Quiver"));
                }
                if (Main.rand.Next(65) == 0)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("Guardians_Courage"));
                }
                if (!Main.dayTime && Main.rand.Next(50) == 0)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("Vampire_Charm"));
                }
            }
        }
    }
}
