using System.Collections.Generic;
using System.Linq;
using Hearstone2.Core.Cards;
using Hearthtone2.MonoFront.Components;
using Microsoft.Xna.Framework;

namespace Hearthtone2.MonoFront
{
	public class PlacedCardsStorage
	{
		private readonly List<PlacedCard> _placedCards;

		public PlacedCardsStorage()
		{
			_placedCards = new List<PlacedCard>();
		}

		public void Clear()
		{
			_placedCards.Clear();
		}

		public void PlaceCard(Card card, Point position, Color color)
		{
			_placedCards.Add(new PlacedCard
				{
					Card = card,
					Position = new Rectangle(position.X, position.Y, PlacedCard.Width, PlacedCard.Height),
					Color = color
				});
		}

		public void PlaceCards(IEnumerable<PlacedCard> placedCards)
		{
			_placedCards.AddRange(placedCards);
		}

		public PlacedCard GetCardByPosition(Point position)
		{
			return _placedCards.FirstOrDefault(c => c.Position.Contains(position));
		}

		public List<PlacedCard> GetAll()
		{
			return _placedCards;
		}
	}
}
