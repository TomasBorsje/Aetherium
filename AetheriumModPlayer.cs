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
        public bool heartOfFrost;
        public bool flameLantern;
        public bool cursedLantern;
        public bool jadeQuiver;
        public bool vampireCharm;
        public int vampireCharmCharge = 0;
        public bool guardiansCourage;
        public bool deadMansPlate;
        public bool theCulling;
        public int cullingCount = 0;
        public bool unobtanium;
        public bool mana_consume;
        public bool jarOfAetherium;
        public bool cosmicShackle;
        public bool cosmicHeart;

        public override void ResetEffects()
        {
            heartOfFrost = false;
            flameLantern = false;
            cursedLantern = false;
            jadeQuiver = false;
            vampireCharm = false;
            guardiansCourage = false;
            deadMansPlate = false;
            unobtanium = false;
            mana_consume = false;
            jarOfAetherium = false;
        }

        public int aetheriumJarTimer = 0;
        

        public override void PostUpdateEquips()
        {
            if (guardiansCourage)
            {
                player.statDefense += (2 + Convert.ToInt32(player.townNPCs * 0.51));
            }
            if (deadMansPlate)
            {
                player.statDefense += (3 + Math.Abs(Convert.ToInt32((Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) / 2) * 1.25)));
            }
            if (player.velocity.Y > 0.4f && jarOfAetherium && aetheriumJarTimer < 90)
            {
                player.velocity.Y = 0.4f;
                Dust.NewDust(player.position, player.width, player.height, DustID.BubbleBlock, Alpha: 50);
                aetheriumJarTimer++;
            }
            else
            {
                if (player.velocity.Y == 0 && jarOfAetherium)
                {
                    aetheriumJarTimer = 0;
                }
            }

        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (target.life < 1 && theCulling && target.lifeMax > 1 && target.damage > 1)
            {
                if (cullingCount >= 10)
                {
                    cullingCount = 0;
                    Item.NewItem(target.getRect(), ItemID.GoldCoin, Main.rand.Next(3));
                    Item.NewItem(target.getRect(), ItemID.SilverCoin, Main.rand.Next(40));
                    Item.NewItem(target.getRect(), ItemID.CopperCoin, Main.rand.Next(66));
                }
                else
                {
                    cullingCount++;
                }
            }
            if (mana_consume && !proj.minion && target.lifeMax > 1 && target.damage > 1)
            {
                if(player.CheckMana(30, true))
                {
                    target.StrikeNPC(20, 1, proj.direction);
                }
            }
            if (vampireCharm)
            {
                if (vampireCharmCharge < 51)
                {
                    if (vampireCharmCharge + damage * 0.05 > 50)
                    {
                        vampireCharmCharge = 50;
                    }
                    else
                    {
                        vampireCharmCharge += Convert.ToInt32(damage * 0.05);
                    }
                }
                else
                {
                    vampireCharmCharge = 50;
                }
            }
            if ((proj.minion || ProjectileID.Sets.MinionShot[proj.type]) && heartOfFrost && !proj.noEnchantments)
            {
                target.AddBuff(BuffID.Frostburn, 30 * damage, false);
            }
            if ((proj.minion || ProjectileID.Sets.MinionShot[proj.type]) && flameLantern && !proj.noEnchantments)
            {
                target.AddBuff(BuffID.OnFire, 60 * 5, false);
            }
            if ((proj.minion || ProjectileID.Sets.MinionShot[proj.type]) && cursedLantern && !proj.noEnchantments && target.onFrostBurn && target.onFire)
            {
                target.AddBuff(BuffID.CursedInferno, 60 * damage, false);
                target.AddBuff(BuffID.ShadowFlame, 60 * damage, false);
            }
            if(proj.arrow && crit && jadeQuiver)
            {
                player.statLife += 5;
                player.HealEffect(5);
            }
        }

        

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            
            if (mana_consume && !item.summon && target.lifeMax > 1 && target.damage > 1)
            {
                if (player.CheckMana(30, true))
                {
                    target.StrikeNPC(20, 1, item.direction);
                }
            }
            if (vampireCharm)
            {
                if (vampireCharmCharge < 51)
                {
                    if (vampireCharmCharge + damage * 0.05 > 50)
                    {
                        vampireCharmCharge = 50;
                    }
                    else
                    {
                        vampireCharmCharge += Convert.ToInt32(damage * 0.05);
                    }
                }
                else
                {
                    vampireCharmCharge = 50;
                }
            }
            if(target.life < 1 && theCulling && target.lifeMax > 1 && target.damage > 1)
            {
                if(cullingCount >= 10)
                {
                    cullingCount = 0;
                    Item.NewItem(target.getRect(), ItemID.GoldCoin, Main.rand.Next(3));
                    Item.NewItem(target.getRect(), ItemID.SilverCoin, Main.rand.Next(40));
                    Item.NewItem(target.getRect(), ItemID.CopperCoin, Main.rand.Next(66));
                }
                else
                {
                    cullingCount++;
                }
            }
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (vampireCharm)
            {
                if (player.statLife + vampireCharmCharge > player.statLifeMax)
                {
                    player.statLife = player.statLifeMax;
                }
                else
                {
                    player.statLife += vampireCharmCharge;
                }
                if (vampireCharmCharge != 0)
                {
                    player.HealEffect(vampireCharmCharge);
                }
                vampireCharmCharge = 0;
            }
            if (cosmicShackle)
            {
                int manaGain = Convert.ToInt32(damage * 1.5);
                player.statMana += manaGain;
                player.ManaEffect(manaGain);
            }
        }

        public override void OnConsumeAmmo(Item weapon, Item ammo)
        {
            if (jadeQuiver && player.statLife != player.statLifeMax)
            {
                int bonusHp = Main.rand.Next(1, 3);
                player.statLife += bonusHp;
                player.HealEffect(bonusHp);
            }
        }
    }
}