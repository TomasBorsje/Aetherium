using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Aetherium.Items.Tools
{
    public class Hungry_Pickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hungry Pickaxe");
            Tooltip.SetDefault("Inflicts strong knockback\nIt hungers...");
        }

        public override void SetDefaults()
        {
            item.damage = 16;
            item.width = 44;
            item.height = 44;
            item.useTime = 15;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.knockBack = 10;
            item.crit = 9;
            item.pick = 110;
            item.value = 10000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(20))
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Blood);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Crafting.Bar_Of_Viscera>(),12);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
