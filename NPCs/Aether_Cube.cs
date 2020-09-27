using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.NPCs
{
    public class Aether_Cube : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aether Cube (PLACEHOLDER)");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 32;
            npc.damage = 11;
            npc.defense = 3;
            npc.lifeMax = 350;
            npc.noTileCollide = true;
            npc.HitSound = new Terraria.Audio.LegacySoundStyle(SoundID.NPCHit4.SoundId, 1);
            npc.DeathSound = new Terraria.Audio.LegacySoundStyle(SoundID.NPCDeath4.SoundId, 1);
            npc.value = 600f;
            npc.knockBackResist = 0.5f;
            npc.noGravity = true;
            npc.aiStyle = -1;
            //aiType = NPCID.BlueSlime;
            //animationType = NPCID.BlueSlime;
            banner = Item.NPCtoBanner(NPCID.BlueSlime);
            bannerItem = Item.BannerToItem(banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0f;
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
            npc.spriteDirection = npc.direction;
            if (AI_Timer<10)
            {
                npc.frame.Y = 0 * frameHeight;
            }
            else
            {
                npc.frame.Y = 1 * frameHeight;
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
            Item.NewItem(npc.getRect(), ItemID.Gel, Main.rand.Next(1, 4));
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
