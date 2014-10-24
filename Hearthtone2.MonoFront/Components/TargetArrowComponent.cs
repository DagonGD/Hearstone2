using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront.Components
{
	public class TargetArrowComponent : DrawableGameComponent
	{
		private readonly Hearthtone2Game _game;
		private Texture2D _arrowTexture;
		private Point _mousePosition;

		public TargetArrowComponent(Hearthtone2Game game) : base(game)
		{
			_game = game;
		}

		protected override void LoadContent()
		{
			_arrowTexture = new Texture2D(_game.GraphicsDevice, 1, 1);
			_arrowTexture.SetData<Color>(new Color[] {Color.Red});

			base.LoadContent();
		}

		public override void Update(GameTime gameTime)
		{
			var mouseState = Mouse.GetState();
			_mousePosition = mouseState.Position;

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			if (_game.CurrentGameMode == GameMode.SelectTarget)
			{
				var spriteBatch = new SpriteBatch(_game.GraphicsDevice);
				spriteBatch.Begin();
				DrawLine(spriteBatch, 
					new Vector2(_game.CurrentlyPlayingCard.Position.Center.X, _game.CurrentlyPlayingCard.Position.Center.Y),
					new Vector2(_mousePosition.X, _mousePosition.Y)
					);
				spriteBatch.End();
			}

			base.Draw(gameTime);
		}

		void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end)
		{
			Vector2 edge = end - start;
			// calculate angle to rotate line
			float angle =
				(float)Math.Atan2(edge.Y, edge.X);


			sb.Draw(_arrowTexture,
				new Rectangle(// rectangle defines shape of line and position of start of line
					(int)start.X,
					(int)start.Y,
					(int)edge.Length(), //sb will strech the texture to fill this rectangle
					1), //width of line, change this to make thicker line
				null,
				Color.Red, //colour of line
				angle,     //angle of line (calulated above)
				new Vector2(0, 0), // point in line about which to rotate
				SpriteEffects.None,
				0);

		}
	}
}
