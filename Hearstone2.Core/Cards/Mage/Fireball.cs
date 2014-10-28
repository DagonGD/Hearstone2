using Hearstone2.Core.Heroes;

namespace Hearstone2.Core.Cards.Mage
{
	public class Fireball: Spell, IMinionTargetSpell, IHeroTargetSpell
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
			target.ReceiveDamage(6);
			base.Play();
		}

	    public bool CanPlay(Minion target)
	    {
	        return base.CanPlay();
	    }

	    public void Play(Hero target)
	    {
	        target.ReceiveDamage(6);
            base.Play();
	    }
	}
}
