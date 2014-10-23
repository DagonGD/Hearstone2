using Hearstone2.Core.Cards;
using Microsoft.Xna.Framework;

namespace Hearthtone2.MonoFront.Components
{
	public class PlacedCard
	{
		public Card Card { get; set; }
		public Rectangle Position { get; set; }
		public Color Color { get; set; }

		public PlacedCard()
		{
			Color = Color.White;
		}
	}
}
