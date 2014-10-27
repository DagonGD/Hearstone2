using Hearstone2.Core.Cards;
using Microsoft.Xna.Framework;

namespace Hearthtone2.MonoFront.Components
{
	public class PlacedCard
	{
		//Sizes
		public const int Width = 307 / 2;
		public const int Height = 465 / 2;

		public ManaCostCard Card { get; set; }
		public Rectangle Position { get; set; }
		public Color Color { get; set; }

		public PlacedCard()
		{
			Color = Color.White;
		}
	}
}
