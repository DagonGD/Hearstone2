using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront.Components
{
	public class TableComponent : BaseGameComponent
	{
	    private Texture2D _backGround;

		public TableComponent(Hearthtone2Game game)
			: base(game, new Rectangle(0,0,game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height))
		{
		}

		public override void Initialize()
		{
			Game.Table.CurrentPlayer.GainMana();
			Game.Table.CurrentPlayer.DrawCard();

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_backGround = Game.Content.Load<Texture2D>("Backgrounds//bg1");

			base.LoadContent();
		}

		public override void KeyPressed(Keys key)
		{
			switch (key)
			{
				case Keys.Space:
					Game.ResetGameMode();
					Game.Table.NextPlayer();
					break;
			}
		}

		public override void OnRightClick()
		{
			Game.ResetGameMode();
		}

		public override void Draw(GameTime gameTime)
		{
			var spriteBatch = new SpriteBatch(Game.GraphicsDevice);
			spriteBatch.Begin();
            spriteBatch.Draw(_backGround, Position, Color.Wheat);
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
