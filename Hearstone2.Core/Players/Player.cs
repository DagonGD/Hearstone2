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
        public int Mana { get; set; }

		public Player()
		{
			Hand = new List<Card>();
			Deck = new List<Card>();
			PlacedMinions = new List<Minion>();
		    Mana = 10;
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
		    if (Mana < card.ManaCost)
		    {
		        return;
		    }
		    Mana = Mana - card.ManaCost;
            Hand.Remove(card);

		    if (card is Minion)
			{
				PlacedMinions.Add(card as Minion);
				return;
			}
		}
	}
}
