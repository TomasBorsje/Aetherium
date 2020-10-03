using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;
namespace Aetherium.Dusts
{
    class Cloud : ModDust
    {
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			//dust.frame = new Rectangle(0, 0, 7, 7);
			dust.rotation = 0;
			dust.velocity *= 0;
			//If our texture had 2 different dust on top of each other (a 30x60 pixel image), we might do this:
			dust.frame = new Rectangle(0, 0 * 24, 34, 24);
		}

		public override bool Update(Dust dust)
		{
			dust.scale -= 0.001f;
			dust.frame = new Rectangle(0, (int)Math.Round(0.5+Math.Sin(((dust.scale)-Math.Round(dust.scale, 1))*MathHelper.TwoPi)) * 24, 34, 24);
			if (dust.scale < 0.25)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
