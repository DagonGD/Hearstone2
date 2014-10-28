using Hearstone2.Core.Heroes;

namespace Hearstone2.Core.Cards.Druid
{
    public class HealingTouch:Spell, IMinionTargetSpell, IHeroTargetSpell
    {
        public override string Title
        {
            get { return "Healing Touch"; }
        }

        public override int ManaCost
        {
            get { return 3; }
        }

        public void Play(Minion target)
        {
            target.Heal(8);
            base.Play();
        }

        public bool CanPlay(Minion target)
        {
            return true;
        }

        public void Play(Hero target)
        {
            target.Heal(8);
            base.Play();
        }
    }
}
