using Aetherium.Items.Crafting;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Items.Weapons
{
	public class Molten_Edge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Molten Edge");
			Tooltip.SetDefault("Shoots bouncing fireballs");
		}
		public override void SetDefaults()
		{
			item.damage = 32; // The damage your item deals
			item.melee = true; // Whether your item is part of the melee class
			item.width = 42; // The item texture's width
			item.height = 44; // The item texture's height
			item.useTime = 25; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
			item.useAnimation = 25; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
			item.knockBack = 6; // The force of knockback of the weapon. Maximum is 20
			item.value = Item.sellPrice(gold: 2); // The value of the weapon in copper coins
			item.rare = ItemRarityID.Orange; // The rarity of the weapon, from -1 to 13. You can also use ItemRarityID.TheColorRarity
			item.UseSound = SoundID.Item1; // The sound when the weapon is being used
			item.autoReuse = false; // Whether the weapon can be used more than once automatically by holding the use button
			item.crit = 6; // The critical strike chance the weapon has. The player, by default, has 4 critical strike chance
			item.shoot = ProjectileID.BallofFire;
			item.shootSpeed = 8f;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.SwingThrow; // 1 is the useStyle
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if(Main.rand.NextBool(3))
            {
				target.AddBuff(BuffID.OnFire, 180);
            }
        }
        public override bool UseItem(Player player)
        {
			Dust.NewDust(item.position, item.width, item.height, DustID.Fire);
			return false;
        }
    }
}
