using Hearstone2.Core.Heroes;

namespace Hearstone2.Core.Cards.Druid
{
    public class Swipe : Spell, IMinionTargetSpell, IHeroTargetSpell
    {
        public override string Title
        {
            get { return "Swipe"; }
        }

        public override int ManaCost
        {
            get { return 4; }
        }

        public void Play(Minion target)
        {
            target.Owner.PlacedMinions.ForEach(m=>m.ReceiveDamage(1));
            target.ReceiveDamage(3);
            base.Play();
        }

        public bool CanPlay(Minion target)
        {
            return true;
        }

        public void Play(Hero target)
        {
            target.PlacedMinions.ForEach(m => m.ReceiveDamage(1));
            target.ReceiveDamage(4);
            base.Play();
        }
    }
}
