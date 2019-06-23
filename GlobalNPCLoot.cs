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
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneJungle)
                {
                    if(Main.rand.Next(250) == 0)
                    {
                        Item.NewItem(npc.getRect(), mod.ItemType("Windfury_Charm"));
                    }
                }
                if (npc.position.Y > Main.worldSurface)
                {
                    if (Main.rand.Next(750) == 0 && Main.dayTime)
                    {
                        Item.NewItem(npc.getRect(), mod.ItemType("Guardians_Courage"));
                    }
                    if (!Main.dayTime && Main.rand.Next(750) == 0)
                    {
                        Item.NewItem(npc.getRect(), mod.ItemType("Vampire_Charm"));
                    }
                }
                if (npc.position.Y < Main.worldSurface)
                {
                    if (Main.rand.Next(600) == 0)
                    {
                        Item.NewItem(npc.getRect(), mod.ItemType("Pirates_Coinpurse"));
                    }
                    if (Main.hardMode)
                    {
                        if (Main.rand.Next(600) == 0)
                        {
                            Item.NewItem(npc.getRect(), mod.ItemType("Giantslayer_Blade"));
                        }
                    }
                }
            }
        }
    }
}
