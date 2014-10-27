using Hearstone2.Core.Cards;
using Hearstone2.Core.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront.Components
{
    public class HeroAvatarComponent : DrawableGameComponent
    {
        public const int Width = 87;
        public const int Height = 100;

        private readonly Hearthtone2Game _game;
        private readonly Hero _player;
        private readonly Rectangle _position;
        private MouseState _oldMouseState;

        public HeroAvatarComponent(Hearthtone2Game game, Hero player, Point position)
            : base(game)
        {
            _game = game;
            _player = player;
            _position = new Rectangle(position.X, position.Y, Width, Height);
        }

        public override void Update(GameTime gameTime)
        {
            var newMouseState = Mouse.GetState();

            if (_game.CurrentGameMode == GameMode.SelectTarget && newMouseState.LeftButton == ButtonState.Pressed && _oldMouseState.LeftButton == ButtonState.Released && _position.Contains(newMouseState.Position))
            {
                var heroTargetSpell = _game.CurrentlyPlayingCard.Card as IHeroTargetSpell;
                if (heroTargetSpell != null && _game.CurrentlyPlayingCard.Card.CanPlay())
                {
                    heroTargetSpell.Play(_player);
                    _game.CurrentGameMode = GameMode.SelectCard;
                    _game.CurrentlyPlayingCard = null;
                }
                else
                {
                    var minion = _game.CurrentlyPlayingCard.Card as Minion;
                    if (minion != null && minion.CanFight)
                    {
                        minion.DealDamage(_player);
                        _game.CurrentGameMode = GameMode.SelectCard;
                        _game.CurrentlyPlayingCard = null;
                    }
                }
            }

            _oldMouseState = newMouseState;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = new SpriteBatch(_game.GraphicsDevice);
            spriteBatch.Begin();
            spriteBatch.Draw(_game.AvatarStorage.GetAvatar(_player.GetType()), _position, _player.Health > 0 ? Color.White : Color.Red);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
