namespace Hearstone2.Core.Cards
{
    public interface IMinionTargetSpell
    {
        void Play(Minion target);

        bool CanPlay(Minion target);
    }
}
