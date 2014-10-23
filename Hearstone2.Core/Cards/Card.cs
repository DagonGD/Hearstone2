using Hearstone2.Core.Classes;

namespace Hearstone2.Core.Cards
{
	public abstract class Card
	{
		public abstract string Title { get; }
		public abstract int ManaCost { get; }
		public Class Owner { get; set; }

		/// <summary>
		/// To play any card we need to spend mana and remove this card from hand
		/// </summary>
		public virtual void Play()
		{
			if (Owner.Mana < ManaCost)
			{
				throw new NotEnoughManaException();
			}

			Owner.Mana -= ManaCost;
			Owner.Hand.Remove(this);
		}

		/// <summary>
		/// To play some abstract card you need to have enoght mana
		/// </summary>
		/// <returns></returns>
		public virtual bool CanPlay()
		{
			return Owner.Mana >= ManaCost;
		}
	}
}
