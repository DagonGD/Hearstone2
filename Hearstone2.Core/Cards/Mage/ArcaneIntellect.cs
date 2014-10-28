namespace Hearstone2.Core.Cards.Mage
{
    public class ArcaneIntellect:Spell,ISpellWithoutTarget
    {
        public override string Title
        {
            get { return "ArcaneIntellect"; }
        }

        public override int ManaCost
        {
            get { return 3; }
        }

        public override void Play()
        {
            Owner.DrawCard();
            Owner.DrawCard();

            base.Play();
        }
    }
}
