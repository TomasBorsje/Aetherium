using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

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

        public override void ResetEffects()
        {
            heartOfFrost = false;
            flameLantern = false;
            cursedLantern = false;
            jadeQuiver = false;
            vampireCharm = false;
            guardiansCourage = false;
            deadMansPlate = false;
        }

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
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
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
        }

        public override void OnConsumeAmmo(Item weapon, Item ammo)
        {
            if (jadeQuiver)
            {
                try
                {
                    int bonusHp = Main.rand.Next(1, 3);
                    player.statLife += bonusHp;
                    player.HealEffect(bonusHp);
                }
                catch
                {

                }
            }
        }
    }

    // As a recap. Make a class variable, reset that variable in ResetEffects, and use that variable in the logic of whatever hooks you use

}