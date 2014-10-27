
namespace Hearstone2.Core.Heroes.Hunter
{
	public class Hunter:Hero
	{
		private readonly HeroAbility _heroAbility;

		public Hunter()
		{
			_heroAbility = new HunterAbility(this);
		}


		public override HeroAbility HeroAbility
		{
			get { return _heroAbility; }
		}
	}
}
