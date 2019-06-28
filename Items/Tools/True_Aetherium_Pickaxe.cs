using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aetherium.Items.Tools
{
    public class True_Aetherium_Pickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Aetherium Pickaxe");
        }

        public override void SetDefaults()
        {
            item.damage = 42;
            item.width = 46;
            item.height = 46;
            item.useTime = 5;
            item.useAnimation = 16;
            item.useStyle = 1;
            item.knockBack = 5;
            item.crit = 9;
            item.pick = 210;
            item.value = 10000;
            item.rare = 9;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Tools/True_Aetherium_Pickaxe_Glow");
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(20))
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Electric);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Crafting.True_Aetherium_Bar>(),13);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
