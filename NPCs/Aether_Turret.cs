using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.NPCs
{
    public class Aether_Turret : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Otherwordly Observer");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 32;
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
            banner = Item.NPCtoBanner(NPCID.BlueSlime);
            bannerItem = Item.BannerToItem(banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Cavern.Chance * 0.00f;
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
            npc.velocity *= 0;
            if (npc.HasValidTarget)
            {
                if(npc.Distance(Main.player[npc.target].Center) < 400 && Collision.CanHitLine(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
                {
                    AI_Timer++;
                    if (AI_Timer == 120)
                    {
                        Main.PlaySound(new Terraria.Audio.LegacySoundStyle(2, 8), npc.position);
                        int a = Projectile.NewProjectile(npc.Center, npc.DirectionTo(Main.player[npc.target].Center) * 15f, ProjectileID.ShadowBeamHostile, 20, 0);
                        Main.projectile[a].friendly = false;
                        Main.projectile[a].hostile = true;
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
            else
            {
                AI_Timer = 0;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            
            if (npc.Distance(Main.player[npc.target].Center) < 400 && Collision.CanHitLine(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
            {
                npc.rotation = npc.AngleTo(Main.player[npc.target].position) + 3.14159265359f;
                npc.frame.Y = 1 * frameHeight;
                if (Main.rand.Next(6) == 0)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("Puff"), SpeedX: 0, SpeedY: 0, Alpha: 50);
                }
            }
            else
            {
                npc.rotation = 0;
                npc.frame.Y = 0 * frameHeight;
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
            if(Main.rand.Next(500)==0)
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
