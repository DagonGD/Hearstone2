using Hearstone2.Core.Players;

namespace Hearstone2.Core.Cards
{
	public abstract class Card
	{
		public abstract string Title { get; }
		public abstract int ManaCost { get; }
		public Player Owner { get; set; }

		/// <summary>
		/// To play any card we need to spend mana and remove this card from hand
		/// </summary>
		public virtual void Play()
		{
			Owner.Mana -= ManaCost;
			Owner.Hand.Remove(this);
		}
	}
}
