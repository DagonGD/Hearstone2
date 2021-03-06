﻿using System.Linq;
using Hearstone2.Core.Cards;
using Hearstone2.Core.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Components
{
	public class HandComponent: BaseCardGameComponent
	{
		public HandComponent(Hearthtone2Game game, Hero owner, Point position)
			: base(game, owner, new Rectangle(position.X, position.Y, game.GraphicsDevice.Viewport.Width, PlacedCard.Height))
		{
		}

        public override void Update(GameTime gameTime)
		{
			InitCards(Owner.Hand.Select((card, index) => new PlacedCard { Card = card, Position = new Rectangle(index * 135, Position.Y, PlacedCard.Width, PlacedCard.Height) }).ToList());
			base.Update(gameTime);
		}

		public override void OnCardOver(PlacedCard card)
		{
			if (Game.CurrentGameMode == GameMode.SelectCard && Game.Table.CurrentPlayer == Owner)
			{
				card.Color = card.Card.CanPlay() ? Color.LightGreen : Color.Red;
			}
			else
			{
				card.Color = Color.White;
			}
		}

		public override void OnCardClick(PlacedCard card)
		{
			if (Game.CurrentGameMode == GameMode.SelectCard)
			{
				if ((card.Card is Minion || card.Card is ISpellWithoutTarget) && card.Card.CanPlay())
				{
					card.Card.Play();
                    Game.Table.Cleanup();
                }

				if (card.Card is IMinionTargetSpell)
				{
					Game.SelectTargetFor(card);
				}
			}
		}

		public override void Draw(GameTime gameTime)
		{
			var spriteBatch = new SpriteBatch(Game.GraphicsDevice);
			spriteBatch.Begin();
			foreach (var card in PlacedCards)
			{
				Game.CardDrawer.Draw(card, spriteBatch);
			}
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
