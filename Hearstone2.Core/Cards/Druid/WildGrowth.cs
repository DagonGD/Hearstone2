namespace Hearstone2.Core.Cards.Druid
{
    public class WildGrowth:Spell,ISpellWithoutTarget
    {
        public override string Title
        {
            get { return "WildGrowth"; }
        }

        public override int ManaCost
        {
            get { return 2; }
        }

        public override void Play()
        {
            Owner.MaxMana += 1;
            base.Play();
        }
    }
}
