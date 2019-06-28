using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Aetherium.Tiles
{
    public class Viscera_Block : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            drop = mod.ItemType("Viscera_Block_Item");
            soundType = 3;
            minPick = 150;
            mineResist = 10;
            soundStyle = 9;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Viscera");
            AddMapEntry(new Color(150, 20, 20), name);
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