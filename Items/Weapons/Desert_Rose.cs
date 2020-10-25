using Aetherium.Items.Crafting;
using Aetherium.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Aetherium.Items.Weapons
{
	public class Desert_Rose : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Rose");
			Tooltip.SetDefault("Fires a short ranged storm of bullets all around you\n90% chance to not consume ammo\n\"Let's make this fun!\"");
		}

		public override void SetDefaults()
		{
			item.damage = 3; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 21; // hitbox width of the item
			item.height = 15; // hitbox height of the item
			item.useTime = 1; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 1; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(0, 2, 0, 0); // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Orange; // the color that the item's name will be in-game
			item.UseSound = new Terraria.Audio.LegacySoundStyle(2, 11); // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 400f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(6.283);
			Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(6.283);
			Vector2 perturbedSpeed3 = new Vector2(speedX, speedY).RotatedByRandom(6.283);

			Projectile.NewProjectile(position, new Vector2(perturbedSpeed.X, perturbedSpeed.Y), ProjectileType<Desert_Rose_Bullet>(), damage, 1, player.whoAmI);
			Projectile.NewProjectile(position, new Vector2(perturbedSpeed2.X, perturbedSpeed2.Y), ProjectileType<Desert_Rose_Bullet>(), damage, 1, player.whoAmI);
			Projectile.NewProjectile(position, new Vector2(perturbedSpeed3.X, perturbedSpeed3.Y), ProjectileType<Desert_Rose_Bullet>(), damage, 1, player.whoAmI);
			return false;
		}

        public override bool ConsumeAmmo(Player player)
        {
			return Main.rand.NextBool(3);
        }
	}
}
