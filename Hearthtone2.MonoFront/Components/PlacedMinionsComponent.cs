using System.Linq;
using Hearstone2.Core.Cards;
using Hearstone2.Core.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Components
{
	public class PlacedMinionsComponent : BaseCardGameComponent
	{
		private readonly Hero _player;

	    public PlacedMinionsComponent(Hearthtone2Game game, Hero player, Point position)
			: base(game, new Rectangle(position.X, position.Y, game.GraphicsDevice.Viewport.Width, PlacedCard.Height))
		{
			_player = player;
		}

        public override void Update(GameTime gameTime)
		{
			InitCards(_player.PlacedMinions.Select((card, index) =>new PlacedCard{Card = card,Position = new Rectangle(index*200, Position.Y, PlacedCard.Width, PlacedCard.Height),Color = Color.White}).ToList());

			base.Update(gameTime);
		}

		public override void OnCardOver(PlacedCard card)
		{
			var taunts = PlacedCards.Where(c => ((Minion)c.Card).IsTaunt).ToList();
			var minion = card.Card as Minion;

 			switch (Game.CurrentGameMode)
	        {
		        case GameMode.SelectCard:
					if (Game.Table.CurrentPlayer == _player && _player.IsAlive)
					{
						card.Color = ((Minion)card.Card).CanFight ? Color.LightGreen : Color.Red;
					}
			        break;
		        case GameMode.SelectTarget:
					if (minion.IsTaunt || !taunts.Any() || Game.CurrentlyPlayingCard.Card is IMinionTargetSpell)
			        {
				        card.Color = Color.LightGreen;
			        }
			        else
			        {
				        card.Color = Color.Red;
						taunts.ForEach(t => t.Color = Color.LightGreen);
			        }
			        break;
	        }
		}

		public override void OnCardClick(PlacedCard card)
		{
			var taunts = PlacedCards.Where(c => ((Minion)c.Card).IsTaunt).ToList();
			var targetMinion = card.Card as Minion;

 			switch (Game.CurrentGameMode)
            {
                case GameMode.SelectCard:
					if (targetMinion.CanFight && Game.Table.CurrentPlayer == _player && _player.IsAlive)
                    {
						Game.CurrentlyPlayingCard = card;
						Game.CurrentGameMode = GameMode.SelectTarget;
                    }

                    break;
                case GameMode.SelectTarget:
					if (Game.CurrentlyPlayingCard.Card is IMinionTargetSpell)
                    {
						((IMinionTargetSpell)Game.CurrentlyPlayingCard.Card).Play(targetMinion);
						Game.CurrentlyPlayingCard = null;
						Game.CurrentGameMode = GameMode.SelectCard;
					}
					else if (Game.CurrentlyPlayingCard.Card is Minion)
                    {
	                    if (targetMinion.IsTaunt || !taunts.Any())
	                    {
							((Minion)Game.CurrentlyPlayingCard.Card).DealDamage(card.Card as Minion);
							((Minion)card.Card).DealDamage(Game.CurrentlyPlayingCard.Card as Minion);
							Game.CurrentlyPlayingCard = null;
							Game.CurrentGameMode = GameMode.SelectCard;
	                    }
	                    else
	                    {
		                    //Player should select taunt
	                    }
                    }

					Game.Table.Cleanup();
                    break;
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
