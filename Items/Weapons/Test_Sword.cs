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
    public class Test_Sword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aetherium Sword");
            Tooltip.SetDefault("Changes damage each time the world is reloaded.\n~~ Scripting Test Weapon -- Not for practical use ~~");
        }
        public override void SetDefaults()
        {
            Random rand = new Random();

            item.damage = rand.Next(20, 50);
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shootSpeed = 8f;
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
