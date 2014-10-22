using System.Collections.Generic;
using System.Linq;
using Hearstone2.Core.Cards;

namespace Hearstone2.Core.Players
{
	public abstract class Player
	{
		public List<Card> Hand { get; private set; }
		public List<Card> Deck { get; set; }
		public List<Minion> PlacedMinions { get; private set; }
        public Player Opponent { get; set; }
        public int Mana { get; set; }
		public int MaxMana { get; set; }

		public Player()
		{
			Hand = new List<Card>();
			Deck = new List<Card>();
			PlacedMinions = new List<Minion>();
			MaxMana = 0;
		}

		public abstract void HeroAbility();

		public void ReceiveMana()
		{
			MaxMana++;
			Mana = MaxMana;
		}

		public void DrawCard()
		{
			var card = Deck.FirstOrDefault();

			if (card == null)
			{
				//TODO: Deal damage to player
				return;
			}

			card.Owner = this;
			Hand.Add(card);
			Deck.Remove(card);
		}
	}
}
