using System.Linq;
using Hearstone2.Core.Cards;
using Hearstone2.Core.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Components
{
	public class HandComponent: BaseCardGameComponent
	{
		private readonly Hero _player;

	    public HandComponent(Hearthtone2Game game, Hero player, Point position)
			: base(game, new Rectangle(position.X, position.Y, game.GraphicsDevice.Viewport.Width, PlacedCard.Height))
		{
			_player = player;
		}

        public override void Update(GameTime gameTime)
		{
		    InitCards(_player.Hand.Select((card, index) => new PlacedCard { Card = card, Position = new Rectangle(index * 135, Position.Y, PlacedCard.Width, PlacedCard.Height) }).ToList());
			base.Update(gameTime);
		}

		public override void OnCardOver(PlacedCard card)
		{
			card.Color = card.Card.CanPlay() ? Color.LightGreen : Color.Red;
		}

		public override void OnCardClick(PlacedCard card)
		{
			if (Game.CurrentGameMode == GameMode.SelectCard)
			{
				if ((card.Card is Minion || card.Card is ISpellWithoutTarget) && card.Card.CanPlay())
				{
					card.Card.Play();
				}

				if (card.Card is IMinionTargetSpell)
				{
					Game.CurrentlyPlayingCard = card;
					Game.CurrentGameMode = GameMode.SelectTarget;
				}
			}
		}

		public override void Draw(GameTime gameTime)
		{
			var spriteBatch = new SpriteBatch(Game.GraphicsDevice);
			spriteBatch.Begin();
			foreach (var card in PlacedCards)
			{
				spriteBatch.Draw(Game.CardFaceStorage.GetCardFace(card.Card.GetType()), card.Position, card.Color);
			}
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
