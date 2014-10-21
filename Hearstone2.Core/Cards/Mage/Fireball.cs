namespace Hearstone2.Core.Cards.Mage
{
	public class Fireball: Spell
	{
		public override string Title
		{
			get { return "Fireball"; }
		}

		public override int ManaCost
		{
			get { return 4; }
		}

		public override void Play(Minion target)
		{
			target.DealDamage(6);
		}
	}
}
