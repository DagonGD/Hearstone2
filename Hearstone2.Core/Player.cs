using System.Collections.Generic;
using Hearstone2.Core.Cards;

namespace Hearstone2.Core
{
	public class Player
	{
		public List<Card> Hand { get; set; }
		public List<Card> Deck { get; set; }
	}
}
