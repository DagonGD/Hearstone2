using System.Collections.Generic;
using System.Linq;
using Hearstone2.Core.Cards;
using Hearstone2.Core.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront.Components
{
	public class HandComponent: DrawableGameComponent
	{
        private readonly Hearthtone2Game _game;
		private readonly Class _player;
		private readonly Point _position;
		private readonly List<PlacedCard> _placedCards;
	    private MouseState _oldMouseState;

	    public HandComponent(Hearthtone2Game game, Class player, Point position)
			: base(game)
		{
			_game = game;
			_player = player;
			_position = position;
			_placedCards = new List<PlacedCard>();
		}

        public override void Initialize()
        {
            _oldMouseState = Mouse.GetState();

            base.Initialize();
        }

		public override void Update(GameTime gameTime)
		{
		    _placedCards.Clear();
			_placedCards.AddRange(_player.Hand.Select((card, index) => new PlacedCard { Card = card, Position = new Rectangle(index * 135, _position.Y, PlacedCard.Width, PlacedCard.Height) }));

		    if (_game.Table.CurrentPlayer == _player)
		    {
		        var newMouseState = Mouse.GetState();
		        var targetCard = _placedCards.FirstOrDefault(c => c.Position.Contains(newMouseState.Position));

		        if (targetCard != null)
		        {
		            targetCard.Color = targetCard.Card.CanPlay() ? Color.LightGreen : Color.Red;
                    
		            if (_game.CurrentGameMode == GameMode.SelectCard && newMouseState.LeftButton == ButtonState.Pressed && _oldMouseState.LeftButton == ButtonState.Released)
		            {
                        if ((targetCard.Card is Minion || targetCard.Card is ISpellWithoutTarget) && targetCard.Card.CanPlay())
		                {
		                    targetCard.Card.Play();
		                }

                        if (targetCard.Card is IMinionTargetSpell)
		                {
                            _game.CurrentlyPlayingCard = targetCard;
		                    _game.CurrentGameMode = GameMode.SelectTarget;
		                }
		            }
		        }

		        _oldMouseState = newMouseState;
		    }

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
		}
	}
}
