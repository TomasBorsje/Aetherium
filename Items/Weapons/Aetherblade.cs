using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Aetherium.Items.Weapons
{
    public class Aetherblade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aetherblade");
        }
        public override void SetDefaults()
        {
            item.damage = 140;           //The damage of your weapon
            item.melee = true;          //Is your weapon a melee weapon?
            item.width = 58;            //Weapon's texture's width
            item.height = 58;           //Weapon's texture's height
            item.useTime = 20;          //The time span of using the weapon. Remember in terraria, 60 frames is a second.
            item.useAnimation = 20;         //The time span of the using animation of the weapon, suggest set it the same as useTime.
            item.useStyle = 1;          //The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
            item.knockBack = 6;         //The force of knockback of the weapon. Maximum is 20
            item.value = Item.buyPrice(silver: 50);           //The value of the weapon
            item.rare = 9;              //The rarity of the weapon, from -1 to 13
            item.UseSound = SoundID.Item1; // test      //The sound when the weapon is using
            item.autoReuse = true; //Whether the weapon can use automatically by pressing mousebutton
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 6; i++)
            {
                Dust.NewDust(target.position, target.width, target.height, 15);
            }
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(2))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 15);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Crafting.Bar_Of_Aetherium>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        //public override void AddRecipes()
        //{
        //    ModRecipe recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(ItemID.DirtBlock, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(this);
        //    recipe.AddRecipe();
        //}

    }
}
