using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Items.Consumables
{
    public class Smoke_Bomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Smoke Bomb");
            Tooltip.SetDefault("Use to dash in the direction you are facing\nGrants 'Shadow Dodge' for 1 second upon use");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 99;
            item.rare = 1;
            item.useAnimation = 50;
            item.useTime = 50;
            item.useStyle = 1;
            item.UseSound = new Terraria.Audio.LegacySoundStyle(2, 14);
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            if(Math.Abs(player.velocity.X) < 12)
            {
                for (int i = 0; i < 50; i++)
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.Smoke);
                }
                player.velocity += new Microsoft.Xna.Framework.Vector2(player.direction * 9, 0);
                player.AddBuff(BuffID.Invisibility, 30);
                player.AddBuff(BuffID.ShadowDodge, 30);
            }
            return true;
        }
    }
}
