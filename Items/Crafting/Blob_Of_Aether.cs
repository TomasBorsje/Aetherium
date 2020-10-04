using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Items.Crafting
{
    class Blob_Of_Aether: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blob Of Aether");
            Tooltip.SetDefault("Light and wispy\nCombine at an Aether Altar, found in Sky Islands");
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.value = 100;
            item.rare = ItemRarityID.Blue;
        }

    }
}
