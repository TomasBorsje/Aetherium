using Aetherium.Items.Crafting;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Aetherium.Items.Weapons
{
	public class Skyshard_Sword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skyshard Sword");
			Tooltip.SetDefault("Right click to dash in the direction of your cursor");
		}

		public override void SetDefaults()
		{
			item.damage = 20; // The damage your item deals
			item.melee = true; // Whether your item is part of the melee class
			item.width = 38; // The item texture's width
			item.height = 40; // The item texture's height
			item.useTime = 30; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
			item.useAnimation = 30; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
			item.knockBack = 5; // The force of knockback of the weapon. Maximum is 20
			item.value = Item.buyPrice(gold: 1); // The value of the weapon in copper coins
			item.rare = ItemRarityID.Orange; // The rarity of the weapon, from -1 to 13. You can also use ItemRarityID.TheColorRarity
			item.UseSound = SoundID.Item1; // The sound when the weapon is being used
			item.autoReuse = false; // Whether the weapon can be used more than once automatically by holding the use button
			item.crit = 6; // The critical strike chance the weapon has. The player, by default, has 4 critical strike chance
			item.shoot = ProjectileID.WaterBolt;
			item.shootSpeed = 12f;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.SwingThrow; // 1 is the useStyle
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			
			if (player.altFunctionUse == 2 && Main.myPlayer == player.whoAmI)
			{
				Vector2 dir = player.DirectionTo(Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY));
				dir.Normalize();
				player.velocity = dir * 8f;
			}
			if(player.altFunctionUse==2)
            {
				Main.PlaySound(SoundID.DoubleJump, player.position);
				Dust.NewDust(player.position + new Microsoft.Xna.Framework.Vector2(-24, player.height), player.width + 24, 5, mod.DustType("Cloud"), Alpha: 50, Scale: Main.rand.NextFloat(0.6f, 0.8f));
				Dust.NewDust(player.position + new Microsoft.Xna.Framework.Vector2(-24, player.height), player.width + 24, 5, mod.DustType("Cloud"), Alpha: 50, Scale: Main.rand.NextFloat(0.6f, 0.8f));
				Dust.NewDust(player.position + new Microsoft.Xna.Framework.Vector2(-24, player.height), player.width + 24, 5, mod.DustType("Cloud"), Alpha: 50, Scale: Main.rand.NextFloat(0.6f, 0.8f));
			}
			if (player.altFunctionUse != 2)
			{
				return true;
			}
			return false;
		}

        public override bool CanUseItem(Player player)
        {
			if (player.altFunctionUse == 2)
			{
				item.useTime = 40;
				item.useAnimation = 40;
			}
            else
            {
				item.useTime = 20;
				item.useAnimation = 20;
			}
			return base.CanUseItem(player);
        }

        public override bool AltFunctionUse(Player player)
        {
			return true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Skyshard>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
