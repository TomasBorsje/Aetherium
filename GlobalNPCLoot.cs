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
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSnow)
                {
                    if (Main.rand.Next(250) == 0)
                    {
                        Item.NewItem(npc.getRect(), mod.ItemType("Pocket_Cyclone"));
                    }
                }
                if (npc.type == NPCID.WallofFlesh) //this is where you choose what vanilla npc you want  , for a modded npc add this instead  if (npc.type == mod.NPCType("ModdedNpcName"))
                {
                    if (!AetheriumWorld.spawnViscera)
                    {                                                          //Red  Green Blue
                        
                        //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color
                        for (int k = 0; k < (int)((double)(WorldGen.rockLayer * Main.maxTilesY) * 10E-05); k++)   //40E-05 is how many veins ore is going to spawn , change 40 to a lover value if you want less vains ore or higher value for more veins ore
                        {

                            int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                            int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 200); //this is the coordinates where the veins ore will spawn, so in Cavern layer
                            WorldGen.OreRunner(X, Y, WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(5, 9), (ushort)mod.TileType("Viscera_Block"));   //WorldGen.genRand.Next(9, 15), WorldGen.genRand.Next(5, 9) is the vein ore sizes, so 9 to 15 blocks or 5 to 9 blocks, mod.TileType("CustomOreTile") is the custom tile that will spawn
                        }
                        Main.NewText("Revolting tumors are forming in the depths...", 170, 0, 0);
                    }
                    AetheriumWorld.spawnViscera = true;   //so the message and the ore spawn does not proc(show) when you kill EoC/npc again
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
