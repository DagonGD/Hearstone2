using System;
using System.Collections.Generic;
using System.Linq;
using Hearstone2.Core;
using Hearstone2.Core.Cards;
using Hearstone2.Core.Cards.Druid;
using Hearstone2.Core.Cards.Mage;
using Hearstone2.Core.Cards.Neutral;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront.Components
{
	public class TableComponent : DrawableGameComponent
	{
		//Sizes
		private const int CardWidth = 307/2;
		private const int CardHeight = 465/2;

		private readonly Hearthtone2Game _game;
		private KeyboardState _oldKeyboardState;
		private MouseState _oldMouseState;

		//Textures
		private Dictionary<Type, Texture2D> _cardFaces;
		private Texture2D _cardBack;

		private List<PlacedCard> _placedCards;

		public TableComponent(Hearthtone2Game game)
			: base(game)
		{
			_game = game;
			
		}

		public override void Initialize()
		{
			_oldKeyboardState = Keyboard.GetState();
			_oldMouseState = Mouse.GetState();

			_game.Table.CurrentPlayer.GainMana();
			_game.Table.CurrentPlayer.DrawCard();

			_cardFaces = new Dictionary<Type, Texture2D>();
			_placedCards = new List<PlacedCard>();

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_cardFaces.Add(typeof(IronbarkProtector), _game.Content.Load<Texture2D>("Classes\\Druid\\Cards\\IronbarkProtector"));
			_cardFaces.Add(typeof(Fireball), _game.Content.Load<Texture2D>("Classes\\Mage\\Cards\\Fireball"));
			_cardFaces.Add(typeof(BluegillWarrior), _game.Content.Load<Texture2D>("Classes\\Neutral\\Cards\\BluegillWarrior"));

			_cardBack = _game.Content.Load<Texture2D>("CardBacks\\Card_Back_Legend.png");

			base.LoadContent();
		}

		public override void Update(GameTime gameTime)
		{
			var newKeyboardState = Keyboard.GetState();
			var newMouseState = Mouse.GetState();

			if (newKeyboardState.IsKeyDown(Keys.Space) && _oldKeyboardState.IsKeyUp(Keys.Space))
			{
				_game.Table.NextPlayer();
				_game.Table.CurrentPlayer.GainMana();
                _game.Table.CurrentPlayer.RefreshMinions();
				_game.Table.CurrentPlayer.DrawCard();
			}

			PlaceCards();

			var placedCard = GetCardByPosition(newMouseState.Position);
			
			if (placedCard != null)
			{
				if (placedCard.Card.Owner == _game.Table.CurrentPlayer)
				{
				    if (_game.Table.CurrentPlayer.Hand.Contains(placedCard.Card))
				    {
				        placedCard.Color = placedCard.Card.CanPlay() ? Color.LightGreen : Color.Red;
				    }
                    else if (_game.Table.CurrentPlayer.PlacedMinions.Contains(placedCard.Card))
				    {
                        placedCard.Color = ((Minion)placedCard.Card).CanFight ? Color.LightGreen : Color.Red;
				    }
				}
                else
				{
					placedCard.Color = Color.White;
				}
			}

			if (newMouseState.LeftButton == ButtonState.Pressed)
			{
				if (placedCard != null)
				{
					if (_oldMouseState.LeftButton == ButtonState.Released)
					{
						switch (_game.CurrentGameMode)
						{
							case GameMode.SelectCard:
								if (_game.Table.CurrentPlayer == placedCard.Card.Owner)
								{
								    if (placedCard.Card is Minion)
								    {
                                        if (_game.Table.CurrentPlayer.Hand.Contains(placedCard.Card) && placedCard.Card.CanPlay())
                                        {
                                            placedCard.Card.Play();
                                        }
                                        else
                                        {
                                            if (((Minion) placedCard.Card).CanFight)
                                            {
                                                _game.CurrentlyPlayingCard = placedCard;
												_game.CurrentGameMode = GameMode.SelectTarget;
                                            }
                                        }
								    }

								    if(placedCard.Card is ISpellWithoutTarget)
									{
										placedCard.Card.Play();
									}

									if (placedCard.Card is IMinionTargetSpell)
									{
										_game.CurrentlyPlayingCard = placedCard;
										_game.CurrentGameMode = GameMode.SelectTarget;
									}
								}
								break;
							case GameMode.SelectTarget:
								if (_game.CurrentlyPlayingCard.Card == placedCard.Card)
                                {
                                    return;
                                }

								if (_game.CurrentlyPlayingCard.Card is IMinionTargetSpell && placedCard.Card is Minion && _game.Table.CurrentPlayer.Opponent.PlacedMinions.Contains(placedCard.Card))
								{
									var minionTargetSpell = _game.CurrentlyPlayingCard.Card as IMinionTargetSpell;
									minionTargetSpell.Play(placedCard.Card as Minion);
                                    _game.CurrentlyPlayingCard = null;
									_game.CurrentGameMode = GameMode.SelectCard;
									break;
								}
                                
                                if (_game.CurrentlyPlayingCard.Card is Minion && placedCard.Card is Minion)
                                {
                                    ((Minion) _game.CurrentlyPlayingCard.Card).DealDamage(placedCard.Card as Minion);
                                    ((Minion)placedCard.Card).DealDamage(_game.CurrentlyPlayingCard.Card as Minion);
                                    ((Minion) _game.CurrentlyPlayingCard.Card).CanFight = false;
                                    _game.CurrentlyPlayingCard = null;
									_game.CurrentGameMode = GameMode.SelectCard;
                                    break;
                                }
                                
								break;
						}
					}
				}

				_game.Table.Cleanup();
			}

			if (newMouseState.RightButton == ButtonState.Pressed && _oldMouseState.RightButton == ButtonState.Released)
			{
				_game.CurrentlyPlayingCard = null;
				_game.CurrentGameMode = GameMode.SelectCard;
			}

			_oldKeyboardState = newKeyboardState;
			_oldMouseState = newMouseState;

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			var spriteBatch = new SpriteBatch(_game.GraphicsDevice);
			spriteBatch.Begin();
			DrawCards(spriteBatch);
			spriteBatch.End();

			base.Draw(gameTime);
		}

		private void PlaceCards()
		{
			_placedCards.Clear();

			_placedCards.AddRange(_game.Table.Player1.Hand.Select((card, index) => new PlacedCard { Card = card, Position = new Rectangle(index * 200, 550, CardWidth, CardHeight) }));
			_placedCards.AddRange(_game.Table.Player1.PlacedMinions.Select((card, index) => new PlacedCard { Card = card, Position = new Rectangle(index * 200, 360, CardWidth, CardHeight) }));
			_placedCards.AddRange(_game.Table.Player2.Hand.Select((card, index) => new PlacedCard { Card = card, Position = new Rectangle(index * 200, -20, CardWidth, CardHeight) }));
			_placedCards.AddRange(_game.Table.Player2.PlacedMinions.Select((card, index) => new PlacedCard { Card = card, Position = new Rectangle(index * 200, 170, CardWidth, CardHeight) }));
		}

		private void DrawCards(SpriteBatch spriteBatch)
		{
			foreach (var card in _placedCards)
			{
				spriteBatch.Draw(_cardFaces[card.Card.GetType()], card.Position, card.Color);
			}

			spriteBatch.Draw(_cardBack, new Rectangle(850, -20, CardWidth, CardHeight), _game.Table.Player2.Deck.Any() ? Color.White : Color.Red);
			spriteBatch.Draw(_cardBack, new Rectangle(850, 550, CardWidth, CardHeight), _game.Table.Player1.Deck.Any() ? Color.White : Color.Red);
		}

		private PlacedCard GetCardByPosition(Point position)
		{
			return _placedCards.FirstOrDefault(c => c.Position.Contains(position));
		}
	}
}
