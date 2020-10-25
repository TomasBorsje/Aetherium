using Aetherium.Items.Consumables;
using Aetherium.NPCs.Bosses;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium
{
    class Aetherium : Mod
    {
        public Aetherium()
        {
        }

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if(NPC.AnyNPCs(ModContent.NPCType<Fire_Slime>()) || NPC.AnyNPCs(ModContent.NPCType<Ice_Slime>()) || NPC.AnyNPCs(ModContent.NPCType<Earth_Slime>()) || NPC.AnyNPCs(ModContent.NPCType<Desert_Slime>()))
            {
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/Flamewall");
				priority = MusicPriority.BossMedium;
			}
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			AetheriumMessageType msgType = (AetheriumMessageType)reader.ReadByte();
			switch (msgType)
			{
				case AetheriumMessageType.SyncNPCAI:
				{
					int npcID = reader.ReadInt32();
					float ai2 = reader.ReadSingle();
					Main.npc[npcID].ai[2] = ai2;
					break;
				}
			}
		}

		public override void PostSetupContent()
		{
			// Showcases mod support with Boss Checklist without referencing the mod
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddBoss",
					4.5f,
					new List<int> { ModContent.NPCType<Fire_Slime>(), ModContent.NPCType<Earth_Slime>(), ModContent.NPCType<Ice_Slime>(), ModContent.NPCType<Desert_Slime>() },
					this, // Mod
					"Elemental Slimes",
					(Func<bool>)(() => AetheriumWorld.downedElementalSlimes),
					ModContent.ItemType<Coalescing_Slime>(),
					new List<int> {  },
					new List<int> {  },
					"Use a [i:" + ModContent.ItemType<Items.Consumables.Coalescing_Slime>() + "] on the surface"
				);
			}
		}
		internal enum AetheriumMessageType : byte
		{
			SyncNPCAI
		}
	}
}
