using Hearstone2.Core.Cards;

namespace Hearstone2.Core.Heroes.Mage
{
	public class MageAbility: HeroAbility, IMinionTargetSpell, IHeroTargetSpell
	{
		public MageAbility(Hero owner) : base(owner)
		{
		}

		public override string Title
		{
			get { return "Fireball"; }
		}

		public override int ManaCost
		{
			get { return 2; }
		}

		public void Play(Minion target)
		{
			target.ReceiveDamage(1);
			base.Play();
		}

		public void Play(Hero target)
		{
			target.ReceiveDamage(1);
			base.Play();
		}
	}
}
