using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.NPCs
{
    public class Aetherium_Slime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aetherium Slime");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 26;
            npc.damage = 11;
            npc.defense = 3;
            npc.lifeMax = 35;
            npc.HitSound = new Terraria.Audio.LegacySoundStyle(SoundID.Splash, 1);
            npc.DeathSound = new Terraria.Audio.LegacySoundStyle(SoundID.NPCDeath4.SoundId, 1);
            npc.value = 600f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 1;
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
            banner = Item.NPCtoBanner(NPCID.BlueSlime);
            bannerItem = Item.BannerToItem(banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0.15f;
        }

        public override void AI()
        {
            if (npc.velocity.Y > 0.5f)
            {
                npc.velocity.Y = 0.5f;
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.BubbleBlock, Alpha: 50);
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
            Item.NewItem(npc.getRect(), mod.ItemType("Blob_Of_Aetherium"), Main.rand.Next(1, 4));
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
            if (Main.rand.Next(4) == 0)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("Blob_Of_Aetherium"));
            }

        }
    }
}
