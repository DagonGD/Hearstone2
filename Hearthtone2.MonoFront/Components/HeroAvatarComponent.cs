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

        private readonly Hero _player;

        public HeroAvatarComponent(Hearthtone2Game game, Hero player, Point position)
			: base(game, new Rectangle(position.X, position.Y, Width, Height))
        {
            _player = player;
        }

		public override void OnClick(Point position)
		{
			if (Game.CurrentGameMode == GameMode.SelectTarget)
			{
				var heroTargetSpell = Game.CurrentlyPlayingCard.Card as IHeroTargetSpell;
				if (heroTargetSpell != null && Game.CurrentlyPlayingCard.Card.CanPlay())
				{
					heroTargetSpell.Play(_player);
					Game.CurrentGameMode = GameMode.SelectCard;
					Game.CurrentlyPlayingCard = null;
				}
				else
				{
					var minion = Game.CurrentlyPlayingCard.Card as Minion;
					if (minion != null && minion.CanFight)
					{
						minion.DealDamage(_player);
						Game.CurrentGameMode = GameMode.SelectCard;
						Game.CurrentlyPlayingCard = null;
					}
				}
			}
		}

        public override void Draw(GameTime gameTime)
        {
			var spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            spriteBatch.Begin();
			spriteBatch.Draw(Game.AvatarStorage.GetAvatar(_player.GetType()), Position, _player.Health > 0 ? Color.White : Color.Red);
			spriteBatch.DrawString(Game.FontsStorage.GetFont(Font.Arial), _player.Health.ToString(), new Vector2(Position.X, Position.Y), Color.White);
			spriteBatch.DrawString(Game.FontsStorage.GetFont(Font.Arial), _player.Mana.ToString() + "/" + _player.MaxMana.ToString(), new Vector2(Position.X + 4 * Width / 5, Position.Y), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
