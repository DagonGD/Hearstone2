using System.Collections.Generic;
using System.Linq;
using Hearstone2.Core.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Components
{
	public class HandComponent: DrawableGameComponent
	{
		private readonly Game _game;
		private readonly Class _player;
		private readonly Point _position;
		private readonly List<PlacedCard> _placedCards;

		public HandComponent(Hearthtone2Game game, Class player, Point position)
			: base(game)
		{
			_game = game;
			_player = player;
			_position = position;
			_placedCards = new List<PlacedCard>();
		}

		public override void Update(GameTime gameTime)
		{
			_placedCards.Clear();
			_placedCards.AddRange(_player.Hand.Select((card, index) => new PlacedCard { Card = card, Position = new Rectangle(index * 135, _position.Y, PlacedCard.Width, PlacedCard.Height) }));
			
			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			var spriteBatch = new SpriteBatch(_game.GraphicsDevice);
			spriteBatch.Begin();
			foreach (var card in _placedCards)
			{
				spriteBatch.Draw(_game.CardFaceStorage.GetCardFace(card.Card.GetType()), card.Position, card.Color);
			}
			spriteBatch.End();

			base.Draw(gameTime);

			base.Draw(gameTime);
		}
	}
}
