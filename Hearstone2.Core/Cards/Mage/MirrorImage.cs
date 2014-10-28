namespace Hearstone2.Core.Cards.Mage
{
    public class MirrorImage:Minion
    {
        public override string Title
        {
            get { return "Mirror Image"; }
        }

        public override int ManaCost
        {
            get { return 0; }
        }

        public override bool CanBeInDeck { get { return false; } }

        public override int BaseDamage
        {
            get { return 0; }
        }

        public override int BaseHealth
        {
            get { return 2; }
        }

        public override bool IsTaunt { get { return true; } }
    }
}
