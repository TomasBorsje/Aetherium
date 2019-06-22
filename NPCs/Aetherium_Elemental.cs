using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Aetherium.NPCs
{
    // Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/blushiemagic/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
    public class Aetherium_Elemental : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aetherium Elemental");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 75;
            npc.damage = 20;
            npc.defense = 5;
            npc.lifeMax = 53;
            npc.HitSound = new Terraria.Audio.LegacySoundStyle(SoundID.Splash, 1);
            npc.DeathSound = new Terraria.Audio.LegacySoundStyle(4, 6);
            npc.value = 600f;
            npc.knockBackResist = 0.5f;
            aiType = -1;
            banner = Item.NPCtoBanner(NPCID.AngryNimbus);
            bannerItem = Item.BannerToItem(banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode != true)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.13f;
            }
            else
            {
                return SpawnCondition.OverworldDaySlime.Chance * 0.002f;
            }
        }

        public string AI_STATE = "waiting";
        public bool hasJumped = false;

        public override void AI()
        {
            if (Main.rand.Next(6) == 0)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.BubbleBlock);
            }
            npc.netUpdate = true;
            if (Main.dayTime)
            {
                npc.StrikeNPC(npc.lifeMax, 0, npc.direction);
            }
            npc.TargetClosest(true);
            if(npc.velocity == new Microsoft.Xna.Framework.Vector2(0, 0))
            {
                npc.velocity.Y -= 4f;
            }
            if (npc.ai[0] > 180 && !hasJumped)
            {
                AI_STATE = "jumping";
            }
            else
            {
                AI_STATE = "waiting";
            }
            if (Main.rand.Next(425) == 0)
            {
                Main.PlaySound(new Terraria.Audio.LegacySoundStyle(32, 43), npc.position);
            }
            else if (Main.rand.Next(425) == 0)
            {
                Main.PlaySound(new Terraria.Audio.LegacySoundStyle(32, 42), npc.position);
            }
            if (AI_STATE == "jumping")
            {
                npc.velocity.Y -= 7f;
                hasJumped = true;
                if (Math.Abs(npc.velocity.X) < 2f)
                {
                    npc.velocity.X *= 6;
                }
            }
            else if (hasJumped && npc.velocity.Y > 0)
            {
                npc.velocity.Y -= 7f;
                npc.ai[0] = 0;
                hasJumped = false;
                Main.PlaySound(new Terraria.Audio.LegacySoundStyle(2, 21), npc.position);
                if (Math.Abs(npc.velocity.X) < 2f)
                {
                    npc.velocity.X *= 6;
                }
                for (int i = 0; i < 9; i++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.BubbleBlock);
                }
            }
            npc.FaceTarget();
            if (Math.Abs(npc.velocity.X) < 1f)
            {
                npc.velocity += new Microsoft.Xna.Framework.Vector2(npc.direction * 0.2f, 0);
            }
            npc.ai[0]++;
         //   npc.HealEffect(Convert.ToInt32(npc.ai[0]));
         //   npc.velocity.Y += (float)Math.Sin(npc.ai[0])*1f;
        }

        public override void NPCLoot()
        {
            for (int i = 0; i < 7; i++)
            {
                int dustType = DustID.BubbleBlock;
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
            }
            Item.NewItem(npc.getRect(), mod.ItemType("Blob_Of_Aetherium"), Main.rand.Next(2,5));
            if (Main.rand.Next(100)==0)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("Jar_Of_Aetherium"), 1);
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 4; i++)
            {
                int dustType = DustID.BubbleBlock;
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
            }
        }
    }
}