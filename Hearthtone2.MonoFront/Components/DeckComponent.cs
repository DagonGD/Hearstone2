using System.Linq;
using Hearstone2.Core.Heroes;
using Hearthtone2.MonoFront.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Components
{
	public class DeckComponent : BaseOwnedComponent
	{
		private Texture2D _cardBack;
		private bool _isMouseInside;

		public DeckComponent(Hearthtone2Game game, Hero owner, Point position)
			: base(game, owner, new Rectangle(position.X, position.Y, PlacedCard.Width, PlacedCard.Height))
		{
		}

		protected override void LoadContent()
		{
			_cardBack = Game.Content.Load<Texture2D>("CardBacks\\Card_Back_Legend.png");

			base.LoadContent();
		}

		public override void OnMouseOver(Point position)
		{
			_isMouseInside = true;
		}

		public override void OnMouseOutside(Point position)
		{
			_isMouseInside = false;
		}

		public override void Draw(GameTime gameTime)
		{
			var spriteBatch = new SpriteBatch(Game.GraphicsDevice);
			spriteBatch.Begin();
			spriteBatch.Draw(_cardBack, Position, Owner.Deck.Any() ? Color.White : Color.Red);
			
			if (_isMouseInside)
			{
				spriteBatch.DrawString(Game.FontsStorage.GetFont(Font.Arial), Owner.Deck.Count.ToString(), new Vector2(Position.X + 20, Position.Y + 40), Color.White);
			}

			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
