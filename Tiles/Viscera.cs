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
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("Viscera_Block_Item");
            soundType = 3;
            soundStyle = 9;
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