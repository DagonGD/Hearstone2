using System;
using System.Collections.Generic;
using System.Linq;
using Hearstone2.Core;
using Hearstone2.Core.Cards;
using Hearstone2.Core.Cards.Druid;
using Hearstone2.Core.Cards.Mage;
using Hearstone2.Core.Cards.Neutral;
using Hearstone2.Core.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront.Components
{
	public class TableComponent : DrawableGameComponent
	{
		private const int CardWidth = 307/2;
		private const int CardHeight = 465/2;

		private readonly Game _game;
		private Table _table;
		private KeyboardState _oldState;
		private Class _currentClass;

		//Textures
		private Dictionary<Type, Texture2D> _cardFaces;
		private Texture2D _cardBack;

		public TableComponent(Game game) : base(game)
		{
			_game = game;
		}

		public override void Initialize()
		{
			_oldState = Keyboard.GetState();

			_table = new Table(
				new Druid
				{
					Deck = new List<Card> { new BluegillWarrior(), new IronbarkProtector(), new BluegillWarrior() }
				},
				new Mage
				{
					Deck = new List<Card> { new Fireball() }
				});

			_cardFaces = new Dictionary<Type, Texture2D>();

			_currentClass = _table.Player1;

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
			KeyboardState newState = Keyboard.GetState();

			if (newState.IsKeyDown(Keys.Space) && _oldState.IsKeyUp(Keys.Space))
			{
				PlayerTurn(_currentClass);
				_table.Cleanup();
				_currentClass = _currentClass.Opponent;
			}

			_oldState = newState;
			base.Update(gameTime);
		}

		private static void PlayerTurn(Class @class)
		{
			@class.GainMana();
			@class.DrawCard();

			var firstCard = @class.Hand.FirstOrDefault(c=>c.CanPlay());

			if (firstCard == null)
			{
				return;
			}

			if (firstCard is Minion)
			{
				firstCard.Play();
				return;
			}

			if (firstCard is ISpellWithoutTarget)
			{
				((ISpellWithoutTarget)firstCard).Play();
				return;
			}

			if (firstCard is IMinionTargetSpell)
			{
				var target = @class.Opponent.PlacedMinions.FirstOrDefault();

				if (target != null)
				{
					((IMinionTargetSpell)firstCard).Play(target);
				}
			}
		}

		public override void Draw(GameTime gameTime)
		{
			var spriteBatch = new SpriteBatch(_game.GraphicsDevice);
			spriteBatch.Begin();

			DrawPlayer1(spriteBatch);
			DrawPlayer2(spriteBatch);

			spriteBatch.End();

			base.Draw(gameTime);
		}

		private void DrawPlayer1(SpriteBatch spriteBatch)
		{
			for (int index = 0; index < _table.Player1.Hand.Count; index++)
			{
				var card = _table.Player1.Hand[index];
				spriteBatch.Draw(_cardFaces[card.GetType()], new Rectangle(index*200, 550, CardWidth, CardHeight), Color.White);
			}

			for (int index = 0; index < _table.Player1.PlacedMinions.Count; index++)
			{
				var card = _table.Player1.PlacedMinions[index];
				spriteBatch.Draw(_cardFaces[card.GetType()], new Rectangle(index*200, 350, CardWidth, CardHeight), Color.White);
			}

			if (_table.Player1.Deck.Any())
			{
				spriteBatch.Draw(_cardBack, new Rectangle(850, 550, CardWidth, CardHeight), Color.White);
			}
		}

		private void DrawPlayer2(SpriteBatch spriteBatch)
		{
			for (int index = 0; index < _table.Player2.Hand.Count; index++)
			{
				var card = _table.Player2.Hand[index];
				spriteBatch.Draw(_cardFaces[card.GetType()], new Rectangle(index*200, -20, CardWidth, CardHeight), Color.White);
			}

			for (int index = 0; index < _table.Player2.PlacedMinions.Count; index++)
			{
				var card = _table.Player2.PlacedMinions[index];
				spriteBatch.Draw(_cardFaces[card.GetType()], new Rectangle(index*200, 200, CardWidth, CardHeight), Color.White);
			}

			if (_table.Player2.Deck.Any())
			{
				spriteBatch.Draw(_cardBack, new Rectangle(850, -20, CardWidth, CardHeight), Color.White);
			}
		}
	}
}
