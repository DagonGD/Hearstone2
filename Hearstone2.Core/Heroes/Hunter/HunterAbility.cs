using Hearstone2.Core.Cards;

namespace Hearstone2.Core.Heroes.Hunter
{
	public class HunterAbility: HeroAbility, ISpellWithoutTarget
	{
		public HunterAbility(Hero owner) : base(owner)
		{
		}

		public override string Title
		{
			get { return "Steady shot"; }
		}

		public override void Play()
		{
			Owner.Opponent.ReceiveDamage(2);

			base.Play();
		}
	}
}
