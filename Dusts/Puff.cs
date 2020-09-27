using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
namespace Aetherium.Dusts
{
    class Puff : ModDust
    {
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			//dust.frame = new Rectangle(0, 0, 7, 7);
			dust.rotation = Main.rand.Next(361);
			//If our texture had 2 different dust on top of each other (a 30x60 pixel image), we might do this:
			dust.frame = new Rectangle(0, Main.rand.Next(2) * 7, 7, 7);
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.scale -= 0.01f;
			dust.rotation += 0.01f;
			if (dust.scale < 0.75f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
