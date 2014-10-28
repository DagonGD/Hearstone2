namespace Hearstone2.Core.Cards.Mage
{
    public class MirrorImages:Spell,ISpellWithoutTarget
    {
        public override string Title
        {
            get { return "Mirror Image"; }
        }

        public override int ManaCost
        {
            get { return 1; }
        }

        public override void Play()
        {
            new MirrorImage { Owner = Owner }.Play();
            new MirrorImage { Owner = Owner }.Play();

            base.Play();
        }
    }
}
