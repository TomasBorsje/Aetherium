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
    public class Aetherium_Staff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aetherium Staff");
            Tooltip.SetDefault("Fires an orb that returns to you after some time");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 11;
            item.magic = true;
            item.mana = 11;
            item.width = 42;
            item.height = 40;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = 10000;
            item.rare = 9;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Aetherium_Staff_Bolt");
            item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Crafting.Bar_Of_Aetherium>(),8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
