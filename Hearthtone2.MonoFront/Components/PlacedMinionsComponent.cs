using System.Collections.Generic;
using System.Linq;
using Hearstone2.Core.Cards;
using Hearstone2.Core.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront.Components
{
	public class PlacedMinionsComponent: DrawableGameComponent
	{
        private readonly Hearthtone2Game _game;
		private readonly Hero _player;
		private readonly Point _position;
		private readonly List<PlacedCard> _placedCards;
	    private MouseState _oldMouseState;

	    public PlacedMinionsComponent(Hearthtone2Game game, Hero player, Point position)
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
			_placedCards.AddRange(_player.PlacedMinions.Select((card, index) => new PlacedCard { Card = card, Position = new Rectangle(index * 200, _position.Y, PlacedCard.Width, PlacedCard.Height) }));

		    
                var newMouseState = Mouse.GetState();
                var targetCard = _placedCards.FirstOrDefault(c => c.Position.Contains(newMouseState.Position));

                if (targetCard != null)
                {
					if (_game.Table.CurrentPlayer == _player && _player.IsAlive)
                    {
                        targetCard.Color = ((Minion) targetCard.Card).CanFight ? Color.LightGreen : Color.Red;
                    }

                    if (newMouseState.LeftButton == ButtonState.Pressed && _oldMouseState.LeftButton == ButtonState.Released)
                    {
                        var minion = (Minion)targetCard.Card;

                        switch (_game.CurrentGameMode)
                        {
                            case GameMode.SelectCard:
								if (minion.CanFight && _game.Table.CurrentPlayer == _player && _player.IsAlive)
                                {
                                    _game.CurrentlyPlayingCard = targetCard;
                                    _game.CurrentGameMode = GameMode.SelectTarget;
                                }

                                break;
                            case GameMode.SelectTarget:
                                if (_game.CurrentlyPlayingCard.Card is IMinionTargetSpell)
                                {
                                    ((IMinionTargetSpell)_game.CurrentlyPlayingCard.Card).Play(minion);
                                    _game.CurrentlyPlayingCard = null;
                                    _game.CurrentGameMode = GameMode.SelectCard;
                                } else if (_game.CurrentlyPlayingCard.Card is Minion)
                                {
                                    ((Minion)_game.CurrentlyPlayingCard.Card).DealDamage(targetCard.Card as Minion);
                                    ((Minion)targetCard.Card).DealDamage(_game.CurrentlyPlayingCard.Card as Minion);
                                    _game.CurrentlyPlayingCard = null;
                                    _game.CurrentGameMode = GameMode.SelectCard;
                                }

                                _game.Table.Cleanup();
                                break;
                        }
                    }
		    }

            _oldMouseState = newMouseState;

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
