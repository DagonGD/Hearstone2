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
            Owner.GainArmor(1);
			target.ReceiveDamage(1);
			target.DealDamage(Owner);
		}

	    public bool CanPlay(Minion target)
	    {
	        return target.Owner.CanMinionBeATargetOfAttack(target) && base.CanPlay();
	    }

	    public void Play(Hero target)
		{
            Owner.GainArmor(1);
			target.ReceiveDamage(1);
		}
	}
}
