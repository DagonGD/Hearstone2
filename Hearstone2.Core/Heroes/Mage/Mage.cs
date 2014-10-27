namespace Hearstone2.Core.Heroes.Mage
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
