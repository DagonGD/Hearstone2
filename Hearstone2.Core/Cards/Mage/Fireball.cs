namespace Hearstone2.Core.Cards.Mage
{
	public class Fireball: Spell, IMinionTargetSpell
	{
		public override string Title
		{
			get { return "Fireball"; }
		}

		public override int ManaCost
		{
			get { return 4; }
		}

		public void Play(Minion target)
		{
			target.DealDamage(6);
			base.Play();
		}
	}
}
