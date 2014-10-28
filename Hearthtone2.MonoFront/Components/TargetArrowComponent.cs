using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront.Components
{
	public class TargetArrowComponent : BaseGameComponent
	{
		private Point _mousePosition;

		public TargetArrowComponent(Hearthtone2Game game) 
			: base(game, new Rectangle(0,0,game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height))
		{
		}

		public override void Update(GameTime gameTime)
		{
			var mouseState = Mouse.GetState();
			_mousePosition = mouseState.Position;

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			if (Game.CurrentGameMode == GameMode.SelectTarget)
			{
				var spriteBatch = new SpriteBatch(Game.GraphicsDevice);
				spriteBatch.Begin();
				DrawLine(spriteBatch,
					new Vector2(Game.CurrentlyPlayingCard.Position.Center.X, Game.CurrentlyPlayingCard.Position.Center.Y),
					new Vector2(_mousePosition.X, _mousePosition.Y)
					);
				spriteBatch.End();
			}

			base.Draw(gameTime);
		}
	}
}
