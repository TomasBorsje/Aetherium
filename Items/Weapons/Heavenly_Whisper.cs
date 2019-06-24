using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Aetherium.Items.Weapons
{
    public class Heavenly_Whisper : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heavenly Whisper");
            Tooltip.SetDefault("Rapidly fires skulls");
        }

        public override void SetDefaults()
        {
            item.damage = 33;
            item.magic = true;
            item.mana = 16;
            item.width = 30;
            item.height = 30;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = 10000;
            item.autoReuse = true;
            item.UseSound = new Terraria.Audio.LegacySoundStyle(2, 8);
            item.rare = 4;
            item.shoot = mod.ProjectileType("Heavenly_Whisper_Bolt");
            item.shootSpeed = 13;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BookofSkulls, 1);
            recipe.AddIngredient(mod.ItemType<Crafting.Bar_Of_Aetherium>(),10);
            recipe.AddIngredient(ItemID.FallenStar, 15);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
