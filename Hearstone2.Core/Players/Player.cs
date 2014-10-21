using System.Collections.Generic;
using System.Linq;
using Hearstone2.Core.Cards;

namespace Hearstone2.Core.Players
{
	public abstract class Player
	{
		public List<Card> Hand { get; set; }
		public List<Card> Deck { get; set; }
		public List<Minion> PlacedMinions { get; set; }
        public Player Opponent { get; set; }

		public Player()
		{
			Hand = new List<Card>();
			Deck = new List<Card>();
			PlacedMinions = new List<Minion>();
		}

		public abstract void HeroAbility();

		public void DrawCard()
		{
			var card = Deck.First();
			Hand.Add(card);
			Deck.Remove(card);
		}

		public void PlayCard(Card card)
		{
			if (card is Minion)
			{
				PlacedMinions.Add(card as Minion);
				Hand.Remove(card);
				return;
			}
		}
	}
}
