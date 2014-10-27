using Hearstone2.Core.Cards;

namespace Hearstone2.Core.Heroes
{
	public abstract class HeroAbility:ManaCostCard
	{
		private bool _isExhausted;

		public HeroAbility(Hero owner)
		{
			Owner = owner;
		}

		public void Refresh()
		{
			_isExhausted = false;
		}

		public override bool CanPlay()
		{
			return base.CanPlay() && !_isExhausted;
		}

		public override void Play()
		{
			_isExhausted = true;

			base.Play();
		}
	}
}
