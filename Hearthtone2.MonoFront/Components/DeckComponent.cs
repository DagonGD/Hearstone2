using System.Linq;
using Hearstone2.Core.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Components
{
	public class DeckComponent : DrawableGameComponent
	{
		private readonly Game _game;
		private readonly Hero _player;
		private readonly Point _position;
		private Texture2D _cardBack;

		public DeckComponent(Game game, Hero player, Point position) : base(game)
		{
			_game = game;
			_player = player;
			_position = position;
		}

		protected override void LoadContent()
		{
			_cardBack = _game.Content.Load<Texture2D>("CardBacks\\Card_Back_Legend.png");

			base.LoadContent();
		}

		public override void Draw(GameTime gameTime)
		{
			var spriteBatch = new SpriteBatch(_game.GraphicsDevice);
			spriteBatch.Begin();
			spriteBatch.Draw(_cardBack, new Rectangle(_position.X, _position.Y, PlacedCard.Width, PlacedCard.Height), _player.Deck.Any() ? Color.White : Color.Red);
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
