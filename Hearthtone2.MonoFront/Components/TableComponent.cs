using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront.Components
{
	public class TableComponent : DrawableGameComponent
	{
		private readonly Hearthtone2Game _game;
		private KeyboardState _oldKeyboardState;
		private MouseState _oldMouseState;
	    private Texture2D _backGround;

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

			base.Initialize();
		}

		protected override void LoadContent()
		{
		    _backGround = _game.Content.Load<Texture2D>("Backgrounds//bg1");

			base.LoadContent();
		}

		public override void Update(GameTime gameTime)
		{
			var newKeyboardState = Keyboard.GetState();
			var newMouseState = Mouse.GetState();

			if (newKeyboardState.IsKeyDown(Keys.Space) && _oldKeyboardState.IsKeyUp(Keys.Space))
			{
                _game.CurrentGameMode = GameMode.SelectCard;
			    _game.CurrentlyPlayingCard = null;
				_game.Table.NextPlayer();
				_game.Table.CurrentPlayer.GainMana();
                _game.Table.CurrentPlayer.RefreshMinions();
				_game.Table.CurrentPlayer.HeroAbility.Refresh();
				_game.Table.CurrentPlayer.DrawCard();
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
            spriteBatch.Draw(_backGround, new Rectangle(0, 0, _game.GraphicsDevice.Viewport.Width, _game.GraphicsDevice.Viewport.Height), Color.Wheat);
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
