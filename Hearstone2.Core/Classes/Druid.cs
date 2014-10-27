using Hearstone2.Core.Cards;

namespace Hearstone2.Core.Classes
{
	public class Druid : Hero
	{
		private readonly HeroAbility _heroAbility;

		public Druid()
		{
			_heroAbility = new DruidAbility(this);
		}

		public override HeroAbility HeroAbility
		{
			get { return _heroAbility; }
		}
	}
}
