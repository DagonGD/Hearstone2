using System.Collections.Generic;
using System.Linq;
using Hearstone2.Core.Classes;
using Microsoft.Xna.Framework;

namespace Hearthtone2.MonoFront.Components
{
	public class PlacedMinionsComponent: DrawableGameComponent
	{
		private readonly Game _game;
		private readonly Class _player;
		private readonly Point _position;
		private readonly List<PlacedCard> _placedCards;

		public PlacedMinionsComponent(Game game, Class player, Point position)
			: base(game)
		{
			_game = game;
			_player = player;
			_position = position;
			_placedCards = new List<PlacedCard>();
		}

		public override void Update(GameTime gameTime)
		{
			_placedCards.AddRange(_player.PlacedMinions.Select((card, index) => new PlacedCard { Card = card, Position = new Rectangle(index * 200, 360, PlacedCard.Width, PlacedCard.Height) }));

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);
		}
	}
}
