using Hearstone2.Core.Cards;
using Hearstone2.Core.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront.Components
{
    public class HeroAbilityComponent : DrawableGameComponent
    {
        public const int Width = 90;
        public const int Height = 100;

        private readonly Hearthtone2Game _game;
        private readonly Hero _player;
        private readonly Rectangle _position;
        private MouseState _oldMouseState;
        private Color _color=Color.White;

        public HeroAbilityComponent(Hearthtone2Game game, Hero player, Point position)
            : base(game)
        {
            _game = game;
            _player = player;
            _position = new Rectangle(position.X, position.Y, Width, Height);
        }

        public override void Update(GameTime gameTime)
        {
            var newMouseState = Mouse.GetState();

            if (_game.CurrentGameMode == GameMode.SelectCard && _game.Table.CurrentPlayer == _player)
            {
                _color = _player.HeroAbility.CanPlay() ? Color.LightGreen : Color.Red;

                if (_position.Contains(newMouseState.Position))
                {
                    if (newMouseState.LeftButton == ButtonState.Pressed &&_oldMouseState.LeftButton == ButtonState.Released)
                    {
	                    if (_player.HeroAbility is IMinionTargetSpell || _player.HeroAbility is IHeroTargetSpell)
	                    {
							_game.CurrentlyPlayingCard = new PlacedCard { Card = _player.HeroAbility, Position = _position, Color = Color.White };
							_game.CurrentGameMode = GameMode.SelectTarget;
	                    }
	                    else if(_player.HeroAbility is ISpellWithoutTarget)
	                    {
		                    ((ISpellWithoutTarget)_player.HeroAbility).Play();
	                    }
                    }
                }
                else
                {
                    _color = Color.White;
                }
            }

            _oldMouseState = newMouseState;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = new SpriteBatch(_game.GraphicsDevice);
            spriteBatch.Begin();
            spriteBatch.Draw(_game.AbilityStorage.GetAbility(_player.GetType()), _position, _color);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
