using Hearstone2.Core.Cards;
using Hearstone2.Core.Heroes;
using Hearthtone2.MonoFront.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Components
{
    public class HeroAvatarComponent : BaseGameComponent
    {
        public const int Width = 87;
        public const int Height = 100;

        private readonly Hearthtone2Game _game;
        private readonly Hero _player;

        public HeroAvatarComponent(Hearthtone2Game game, Hero player, Point position)
			: base(game, new Rectangle(position.X, position.Y, Width, Height))
        {
            _game = game;
            _player = player;
        }

        public override void OnClick()
		{
			if (_game.CurrentGameMode == GameMode.SelectTarget)
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
		}

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = new SpriteBatch(_game.GraphicsDevice);
            spriteBatch.Begin();
            spriteBatch.Draw(_game.AvatarStorage.GetAvatar(_player.GetType()), Position, _player.Health > 0 ? Color.White : Color.Red);
			spriteBatch.DrawString(_game.FontsStorage.GetFont(Font.Arial), _player.Health.ToString(), new Vector2(Position.X, Position.Y), Color.White);
			spriteBatch.DrawString(_game.FontsStorage.GetFont(Font.Arial), _player.Mana.ToString() + "/" + _player.MaxMana.ToString(), new Vector2(Position.X + 4 * Width / 5, Position.Y), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
