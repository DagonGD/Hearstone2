using Hearstone2.Core.Cards;

namespace Hearstone2.Core.Classes
{
	public class DruidAbility : HeroAbility, IMinionTargetSpell, IHeroTargetSpell
	{
		public DruidAbility(Hero owner) : base(owner)
		{
		}

		public override string Title
		{
			get { return "Shapeshift"; }
		}

		public override int ManaCost
		{
			get { return 2; }
		}

		public void Play(Minion target)
		{
			throw new System.NotImplementedException();
		}

		public void Play(Hero target)
		{
			throw new System.NotImplementedException();
		}
	}
}
