using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.NPCs
{
    // Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/blushiemagic/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
    public class Aetherium_Slime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aetherium Slime");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            npc.width = 20;
            npc.height = 40;
            npc.damage = 14;
            npc.defense = 3;
            npc.lifeMax = 42;
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
            return SpawnCondition.OverworldDaySlime.Chance * 0.4f;
        }

        public override void AI()
        {
            if(npc.velocity.Y > 0.4f)
            {
                npc.velocity.Y = 0.4f;
            }
            if(npc.velocity.Y > 0f)
            {
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
            Item.NewItem(npc.getRect(), mod.ItemType("Blob_Of_Aetherium"), Main.rand.Next(1,4));
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