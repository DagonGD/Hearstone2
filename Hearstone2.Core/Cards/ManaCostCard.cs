using Hearstone2.Core.Heroes;

namespace Hearstone2.Core.Cards
{
	public abstract class ManaCostCard
	{
		public abstract string Title { get; }
		public abstract int ManaCost { get; }
		public Hero Owner { get; set; }
        public virtual bool CanBeInDeck { get { return true; } }

		/// <summary>
		/// To play any card we need to spend mana
		/// </summary>
		public virtual void Play()
		{
			if (Owner.Mana < ManaCost)
			{
				throw new NotEnoughManaException();
			}

			Owner.Mana -= ManaCost;
		}

		/// <summary>
		/// To play some abstract card you need to have enough mana
		/// </summary>
		/// <returns></returns>
		public virtual bool CanPlay()
		{
			return Owner.Mana >= ManaCost;
		}
	}
}
