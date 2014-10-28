using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Content
{
    public class MiscImageStorage
    {
        public const int ManaCrystalWidth = 25;
        public const int ManaCrystalHeight = 25;

        private readonly Hearthtone2Game _game;
        private Texture2D _manaCrystal;

        public MiscImageStorage(Hearthtone2Game game)
        {
            _game = game;
        }

        public void LoadContent()
        {
            _manaCrystal = _game.Content.Load<Texture2D>("Misc\\ManaCrystal");
        }

        public Texture2D GetManaCrystalImage()
        {
            return _manaCrystal;
        }
    }
}
