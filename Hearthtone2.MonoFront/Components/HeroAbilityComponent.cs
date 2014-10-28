using Hearstone2.Core.Cards;
using Hearstone2.Core.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Components
{
    public class HeroAbilityComponent : BaseGameComponent
    {
        public const int Width = 90;
        public const int Height = 100;

        private readonly Hearthtone2Game _game;
        private readonly Hero _player;
        private Color _color=Color.White;

        public HeroAbilityComponent(Hearthtone2Game game, Hero player, Point position)
			: base(game, new Rectangle(position.X, position.Y, Width, Height))
        {
            _game = game;
            _player = player;
        }

        public override void OnMouseOver()
		{
			if (_game.CurrentGameMode == GameMode.SelectCard && _game.Table.CurrentPlayer == _player)
			{
				_color = _player.HeroAbility.CanPlay() ? Color.LightGreen : Color.Red;
			}
		}

		public override void OnClick()
		{
			if (_player.HeroAbility is IMinionTargetSpell || _player.HeroAbility is IHeroTargetSpell)
			{
				_game.CurrentlyPlayingCard = new PlacedCard { Card = _player.HeroAbility, Position = Position, Color = Color.White };
				_game.CurrentGameMode = GameMode.SelectTarget;
			}
			else if (_player.HeroAbility is ISpellWithoutTarget)
			{
				((ISpellWithoutTarget)_player.HeroAbility).Play();
			}

			base.OnClick();
		}

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = new SpriteBatch(_game.GraphicsDevice);
            spriteBatch.Begin();
            spriteBatch.Draw(_game.AbilityStorage.GetAbility(_player.GetType()), Position, _color);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
