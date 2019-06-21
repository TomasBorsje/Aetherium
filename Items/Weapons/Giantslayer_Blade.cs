using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;


namespace Aetherium.Items.Weapons
{
    public class Giantslayer_Blade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Giantslayer Blade");
            Tooltip.SetDefault("Deals 8% of the enemy's current health as bonus damage\nDoes not work on bosses");
        }
        public override void SetDefaults()
        {
            item.damage = 60;           //The damage of your weapon
            item.melee = true;          //Is your weapon a melee weapon?
            item.width = 48;            //Weapon's texture's width
            item.height = 56;           //Weapon's texture's height
            item.useTime = 30;          //The time span of using the weapon. Remember in terraria, 60 frames is a second.
            item.useAnimation = 30;         //The time span of the using animation of the weapon, suggest set it the same as useTime.
            item.useStyle = 1;          //The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
            item.knockBack = 6;         //The force of knockback of the weapon. Maximum is 20
            item.value = Item.buyPrice(gold: 1);           //The value of the weapon
            item.rare = 4;              //The rarity of the weapon, from -1 to 13
            item.UseSound = SoundID.Item1;      //The sound when the weapon is using
            item.autoReuse = true; //Whether the weapon can use automatically by pressing mousebutton
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (!target.boss)
            {
                target.StrikeNPC(Convert.ToInt32(Math.Round(target.life * 0.08f, 0)), item.knockBack, item.direction);
            }
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
