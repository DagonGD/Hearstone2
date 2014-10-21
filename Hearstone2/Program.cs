using System.Collections.Generic;
using System.Linq;
using Hearstone2.Core;
using Hearstone2.Core.Cards;
using Hearstone2.Core.Cards.Mage;
using Hearstone2.Core.Cards.Neutral;
using Hearstone2.Core.Players;

namespace Hearstone2
{
	class Program
	{
		static void Main(string[] args)
		{
			var table = new Table
				{
					Player1 = new Druid()
						{
							Deck = new List<Card> {new BluegillWarrior()}
						},
					Player2 = new Mage
						{
							Deck = new List<Card> {new Fireball()}
						}
				};

			table.Player1.DrawCard();
			table.Player1.PlayCard(table.Player1.Hand.First());

			table.Player2.DrawCard();
			table.Player2.PlayCard(table.Player2.Hand.First(), table.Player1.PlacedMinions.First());

			table.Cleanup();
		}
	}
}
