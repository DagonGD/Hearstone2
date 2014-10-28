
namespace Hearstone2.Core.Cards.Mage
{
    public class ArcaneExplosion:Spell,ISpellWithoutTarget
    {
        public override string Title
        {
            get { return "ArcaneExplosion"; }
        }

        public override int ManaCost
        {
            get { return 2; }
        }

        public override void Play()
        {
            Owner.Opponent.PlacedMinions.ForEach(m => m.ReceiveDamage(1));
            base.Play();
        }
    }
}
