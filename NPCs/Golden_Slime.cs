using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.NPCs
{
    public class Golden_Slime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Slime");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 26;
            npc.damage = 15;
            npc.defense = 3;
            npc.lifeMax = 70;
            npc.HitSound = new Terraria.Audio.LegacySoundStyle(SoundID.Coins, 1);
            npc.DeathSound = new Terraria.Audio.LegacySoundStyle(SoundID.NPCDeath4.SoundId, 1);
            npc.value = 600f;
            npc.knockBackResist = 0.8f;
            npc.aiStyle = 1;
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
            banner = Item.NPCtoBanner(NPCID.BlueSlime);
            bannerItem = Item.BannerToItem(banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0.015f;
        }

        public override void AI()
        {
            if (Main.rand.Next(10) == 0)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldCoin, SpeedX: 0, SpeedY: 1);
            }
            if (npc.velocity.Y != 0)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldCoin, SpeedX: 0, SpeedY: 1);
            }
        }
        public override void NPCLoot()
        {
            for (int i = 0; i < 7; i++)
            {
                int dustType = DustID.t_Slime;
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
            }
            for (int i = 0; i < 50; i++)
            {
                Dust.NewDust(npc.position + new Microsoft.Xna.Framework.Vector2(-37.5f, -37.5f), 75, 75, DustID.GoldCoin, SpeedX: 0, SpeedY: 0, Alpha: 50);
            }
            Item.NewItem(npc.getRect(), ItemID.Gel, Main.rand.Next(1, 4));
            Item.NewItem(npc.getRect(), ItemID.GoldCoin, Main.rand.Next(1, 4));
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 4; i++)
            {
                int dustType = DustID.t_Slime;
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
            }
            for(int i = 0; i < damage && i < 10; i++)
            {
                int coin = Main.rand.Next(100);
                if (coin <= 2)
                {
                    Item.NewItem(npc.getRect(), ItemID.GoldCoin);
                }
                else if(coin <= 35)
                {
                    Item.NewItem(npc.getRect(), ItemID.SilverCoin);
                }
                else
                {
                    Item.NewItem(npc.getRect(), ItemID.CopperCoin);
                }
            }
        }
    }
}
