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
    public class Overload_Staff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Overload Staff");
            Tooltip.SetDefault("Grapple hook that also functions as a weapon.\n~~ Scripting Test Weapon -- Not for practical use ~~");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.magic = true;
            item.mana = 12;
            item.width = 40;
            item.height = 40;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Overload_Orb");
            item.shootSpeed = 16f;
        }
    }
}
