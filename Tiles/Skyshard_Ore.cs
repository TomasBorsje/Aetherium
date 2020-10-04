using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Tiles
{
    public class Skyshard_Ore : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            drop = mod.ItemType("Skyshard_Ore");
            soundType = 0;
            minPick = 45;
            mineResist = 10;
            soundStyle = 1;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Skyshard Ore");
            AddMapEntry(new Color(170, 230, 230), name);
        }



        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.5f;
            g = 0.5f;
            b = 0.5f;
        }
    }
}