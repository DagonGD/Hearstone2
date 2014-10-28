using Hearstone2.Core.Cards;

namespace Hearstone2.Core.Heroes.Druid
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

		public void Play(Minion target)
		{
			target.ReceiveDamage(1);
			target.DealDamage(Owner);
			Owner.Heal(1);
		}

		public void Play(Hero target)
		{
			target.ReceiveDamage(1);
			Owner.Heal(1);
		}
	}
}
