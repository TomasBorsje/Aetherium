using Aetherium.Items.Crafting;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.NPCs
{
    public class Aether_Spirit : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aether Spirit");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.width = 29;
            npc.height = 24;
            npc.damage = 14;
            npc.defense = 3;
            npc.lifeMax = 45;
            npc.noTileCollide = true;
            npc.HitSound = new Terraria.Audio.LegacySoundStyle(4, 6);
            npc.DeathSound = new Terraria.Audio.LegacySoundStyle(4, 6);
            npc.value = 600f;
            npc.knockBackResist = 0.5f;
            npc.noGravity = true;
            npc.aiStyle = -1;
            //aiType = NPCID.BlueSlime;
            //animationType = NPCID.BlueSlime;
            banner = 0;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.10f;
        }

        private const int AI_State_Slot = 0;
        private const int AI_Timer_Slot = 1;

        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;
        }

        public float AI_Timer
        {
            get => npc.ai[AI_Timer_Slot];
            set => npc.ai[AI_Timer_Slot] = value;
        }

        public override void AI()
        {
            npc.TargetClosest();
            npc.velocity *= 0.99f;
            if (npc.HasValidTarget)
            {
                AI_Timer++;
                if (AI_Timer == 1)
                {
                    Main.PlaySound(new Terraria.Audio.LegacySoundStyle(2, 8), npc.position);
                    Microsoft.Xna.Framework.Vector2 vect = Main.player[npc.target].DirectionFrom(npc.Center);
                    vect.Normalize();
                    npc.velocity = vect * 6;
                }
                else if (AI_Timer > 120)
                {
                    AI_Timer = 0;
                }
            }
            else
            {
                AI_Timer = 0;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.rotation = npc.AngleTo(Main.player[npc.target].position) + 3.14159265359f;
            if (AI_Timer<10)
            {
                npc.frame.Y = 0 * frameHeight;
                for (int i = 0; i < 3; i++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("Puff"), SpeedX: 0, SpeedY: 0, Alpha: 50);
                }
            }
            else
            {
                npc.frame.Y = 1 * frameHeight;
                if (Main.rand.Next(6) == 0)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("Puff"), SpeedX: 0, SpeedY: 0, Alpha: 50);
                }
            }
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
            Item.NewItem(npc.getRect(), ModContent.ItemType<Blob_Of_Aether>(), Main.rand.Next(1, 4));
            if (Main.rand.Next(500)==0)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("Arcane_Comet"), 1);
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
