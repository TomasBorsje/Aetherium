using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Aetherium
{
    public class AetheriumModPlayer : ModPlayer
    {
        public bool aetherWisp;
        public bool furyOfTheStorm;

        int furyOfTheStormTimer, furyOfTheStormDamage, furyOfTheStormProcs, furyOfTheStormCooldown, furyOfTheStormLastEnemyType = 0;
        public bool manaLeech;

        public override void ResetEffects()
        {
            aetherWisp = false;
            furyOfTheStorm = false;
            manaLeech = false;

        }

        public override void SetupStartInventory(IList<Item> items)
        {
            Item wisp = new Item();
            wisp.SetDefaults(mod.ItemType("Aether_Wisp"));
            wisp.stack = 1;
            items.Add(wisp);
        }

        public override void PostUpdateEquips()
        {
            if(furyOfTheStorm)
            {
                if(furyOfTheStormCooldown != 0)
                {
                    furyOfTheStormCooldown--;
                }
                else if(furyOfTheStormProcs > 0)
                {
                    furyOfTheStormTimer++;
                }
                else
                {
                    furyOfTheStormTimer = 0;
                }
                if(furyOfTheStormTimer>90)
                {
                    furyOfTheStormProcs = 0;
                    furyOfTheStormTimer = 0;
                    furyOfTheStormDamage = 0;
                }
            }
            else
            {
                furyOfTheStormTimer = 0;
                furyOfTheStormDamage = 0;
                furyOfTheStormProcs = 0;
                furyOfTheStormCooldown = 0;
            }
        }

        public override void PostUpdate()
        {

        }

        public override void PreUpdateMovement()
        {

        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (furyOfTheStorm)
            {
                if (furyOfTheStormProcs >= 2 && furyOfTheStormCooldown == 0)
                {
                    if (furyOfTheStormTimer < 90 && furyOfTheStormLastEnemyType == target.type)
                    {
                        furyOfTheStormDamage += damage;
                        target.StrikeNPC(furyOfTheStormDamage + damage, 0, proj.direction); // Electrocute the enemy
                        for (int i = 0; i < 10; i++)
                        {
                            Dust.NewDust(target.position, target.width, target.height, DustID.Electric);
                        }
                        Main.PlaySound(SoundID.Item94, target.position);
                        furyOfTheStormTimer = 0;
                        furyOfTheStormDamage = 0;
                        furyOfTheStormProcs = 0;
                        furyOfTheStormCooldown = 300;
                    }
                    else
                    {
                        furyOfTheStormTimer = 0;
                        furyOfTheStormDamage = 0;
                        furyOfTheStormProcs = 0;
                    }
                    furyOfTheStormLastEnemyType = target.type;
                }
                else if (furyOfTheStormCooldown == 0)
                {
                    if (furyOfTheStormTimer < 90)
                    {
                        if (furyOfTheStormProcs > 0 && furyOfTheStormLastEnemyType != target.type)
                        {
                            furyOfTheStormTimer = 0;
                            furyOfTheStormDamage = 0;
                            furyOfTheStormProcs = 0;
                        }
                        else
                        {
                            furyOfTheStormProcs++;
                            furyOfTheStormDamage += damage;
                        }
                        furyOfTheStormLastEnemyType = target.type;
                    }
                }
            }
            if (manaLeech && target.life < 1 && target.lifeMax > 1 && target.damage > 1)
            {
                player.statMana += (int)((player.statManaMax - player.statMana) * 0.4f);
                player.ManaEffect((int)((player.statManaMax - player.statMana) * 0.4f));
            }
        }

        
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (furyOfTheStorm)
            {
                if (furyOfTheStormProcs >= 2 && furyOfTheStormCooldown == 0)
                {
                    if (furyOfTheStormTimer < 90 && furyOfTheStormLastEnemyType == target.type)
                    {
                        furyOfTheStormDamage += damage;
                        target.StrikeNPC(furyOfTheStormDamage + damage, 0, item.direction); // Electrocute the enemy
                        for (int i = 0; i < 10; i++)
                        {
                            Dust.NewDust(target.position, target.width, target.height, DustID.Electric);
                        }
                        Main.PlaySound(SoundID.Item94, target.position);
                        furyOfTheStormTimer = 0;
                        furyOfTheStormDamage = 0;
                        furyOfTheStormProcs = 0;
                        furyOfTheStormCooldown = 300;
                    }
                    else
                    {
                        furyOfTheStormTimer = 0;
                        furyOfTheStormDamage = 0;
                        furyOfTheStormProcs = 0;
                    }
                    furyOfTheStormLastEnemyType = target.type;
                }
                else if (furyOfTheStormCooldown == 0)
                {
                    if (furyOfTheStormTimer < 90)
                    {
                        if (furyOfTheStormProcs > 0 && furyOfTheStormLastEnemyType != target.type)
                        {
                            furyOfTheStormTimer = 0;
                            furyOfTheStormDamage = 0;
                            furyOfTheStormProcs = 0;
                        }
                        else
                        {
                            furyOfTheStormProcs++;
                            furyOfTheStormDamage += damage;
                        }
                        furyOfTheStormLastEnemyType = target.type;
                    }
                }
            }
            if (manaLeech && target.life < 1 && target.lifeMax > 1 && target.damage > 1)
            {
                player.statMana += (int)((player.statManaMax - player.statMana) * 0.4f);
                player.ManaEffect((int)((player.statManaMax - player.statMana) * 0.4f));
            }
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {

        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {

        }

        public override void OnConsumeAmmo(Item weapon, Item ammo)
        {

        }
    }
}