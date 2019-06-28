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
    public class Blood_Biter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Biter");
            Tooltip.SetDefault("Arrows fired inflict strong knockback");
        }

        public override void SetDefaults()
        {
            item.damage = 36;
            item.ranged = true;
            item.width = 16;
            item.height = 32;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 8;
            item.value = 10000;
            item.crit = 12;
            item.rare = 4;
            item.UseSound = new Terraria.Audio.LegacySoundStyle(3, 9);
            item.shoot = 10;
            item.autoReuse = true;
            item.shootSpeed = 12f;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = mod.ProjectileType("Hungry_Arrow");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
            {
                type = mod.ProjectileType<Projectiles.Hungry_Arrow>(); // or ProjectileID.FireArrow;
            }
            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Crafting.Bar_Of_Viscera>(),11);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
