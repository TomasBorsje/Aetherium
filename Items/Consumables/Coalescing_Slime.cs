using Aetherium.Items.Crafting;
using Aetherium.NPCs.Bosses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Aetherium.Items.Consumables
{
    public class Coalescing_Slime : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coalescent Gel");
            Tooltip.SetDefault("Summons the Elemental Slimes");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.rare = ItemRarityID.Orange;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ZoneOverworldHeight && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.Fire_Slime>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.Ice_Slime>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.Desert_Slime>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.Earth_Slime>());
        }

        public override bool UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.Server && Main.myPlayer == player.whoAmI)
            {
                int n1 = NPC.NewNPC((int)player.position.X + 384, (int)player.position.Y - 512, ModContent.NPCType<Fire_Slime>(), ai0: 100f);
                int n2 = NPC.NewNPC((int)player.position.X + 192, (int)player.position.Y - 512, ModContent.NPCType<Ice_Slime>(), ai0: 100f);
                int n3 = NPC.NewNPC((int)player.position.X - 192, (int)player.position.Y - 512, ModContent.NPCType<Earth_Slime>(), ai0: 100f);
                int n4 = NPC.NewNPC((int)player.position.X - 384, (int)player.position.Y - 512, ModContent.NPCType<Desert_Slime>(), ai0: 100f);
                Main.npc[n1].netUpdate = true;
                Main.npc[n2].netUpdate = true;
                Main.npc[n3].netUpdate = true;
                Main.npc[n4].netUpdate = true;
            }
            Main.NewText("The Elemental Slimes have awoken!", Colors.RarityPurple);
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 25);
            recipe.AddIngredient(ModContent.ItemType<Blob_Of_Aether>(), 3);
            recipe.AddIngredient(ItemID.MudBlock, 1);
            recipe.AddIngredient(ItemID.IceBlock, 1);
            recipe.AddIngredient(ItemID.SandBlock, 1);
            recipe.AddIngredient(ItemID.AshBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}