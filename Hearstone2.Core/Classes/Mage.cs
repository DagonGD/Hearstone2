using Hearstone2.Core.Cards;

namespace Hearstone2.Core.Classes
{
	public class Mage : Hero
	{
		private readonly HeroAbility _heroAbility;

		public Mage()
		{
			_heroAbility = new MageAbility(this);
		}

		public override HeroAbility HeroAbility
		{
			get { return _heroAbility; }
		}
	}
}
