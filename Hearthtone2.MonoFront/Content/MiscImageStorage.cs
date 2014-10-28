using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Content
{
    public class MiscImageStorage
    {
        public const int ManaCrystalWidth = 25;
        public const int ManaCrystalHeight = 25;

        private readonly Hearthtone2Game _game;
        private Texture2D _manaCrystal;
        private Texture2D _emptyCard;

        public MiscImageStorage(Hearthtone2Game game)
        {
            _game = game;
        }

        public void LoadContent()
        {
            _manaCrystal = _game.Content.Load<Texture2D>("Misc\\ManaCrystal");
            _emptyCard = _game.Content.Load<Texture2D>("Misc\\EmptyCard");
        }

        public Texture2D GetEmptyCard()
        {
            return _emptyCard;
        }

        public Texture2D GetManaCrystalImage()
        {
            return _manaCrystal;
        }
    }
}
