using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront.Components
{
	public abstract class BaseGameComponent: DrawableGameComponent
	{
		protected readonly Rectangle Position;
		protected new readonly Hearthtone2Game Game;
		private MouseState _oldMouseState;
		private Texture2D _arrowTexture;
		private KeyboardState _oldKeyboardState;

		protected BaseGameComponent(Hearthtone2Game game, Rectangle position)
			: base(game)
		{
			Position = position;
			Game = game;
		}

		public override void Initialize()
		{
			_oldMouseState=new MouseState();

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_arrowTexture = new Texture2D(Game.GraphicsDevice, 1, 1);
			_arrowTexture.SetData<Color>(new Color[] { Color.Red });

			base.LoadContent();
		}

		public override void Update(GameTime gameTime)
		{
			var newMouseState = Mouse.GetState();
			var newKeyboardState = Keyboard.GetState();

			if (Position.Contains(newMouseState.Position))
			{
				OnMouseOver(newMouseState.Position);

				if (newMouseState.LeftButton == ButtonState.Pressed && _oldMouseState.LeftButton == ButtonState.Released)
				{
					OnClick(newMouseState.Position);
				}

				if (newMouseState.RightButton == ButtonState.Pressed && _oldMouseState.RightButton == ButtonState.Released)
				{
					OnRightClick();
				}
			}
			else
			{
				OnMouseOutside(newMouseState.Position);
			}


			foreach (var key in newKeyboardState.GetPressedKeys())
			{
				if (_oldKeyboardState.IsKeyUp(key))
				{
					KeyPressed(key);
				}
			}

			_oldMouseState = newMouseState;
			_oldKeyboardState = newKeyboardState;

			base.Update(gameTime);
		}

		public virtual void OnMouseOver(Point position)
		{
			
		}

		public virtual void OnMouseOutside(Point position)
		{

		}

		public virtual void OnClick(Point position)
		{

		}

		public virtual void OnRightClick()
		{

		}

		public virtual void KeyPressed(Keys key)
		{
			
		}

		/*public override void Draw(GameTime gameTime)
		{
			var spriteBatch = new SpriteBatch(Game.GraphicsDevice);
			spriteBatch.Begin();
			DrawLine(spriteBatch, new Vector2(Position.X, Position.Y), new Vector2(Position.X + Position.Width, Position.Y));
			DrawLine(spriteBatch, new Vector2(Position.X + Position.Width, Position.Y), new Vector2(Position.X + Position.Width, Position.Y + Position.Height));
			DrawLine(spriteBatch, new Vector2(Position.X + Position.Width, Position.Y + Position.Height), new Vector2(Position.X, Position.Y + Position.Height));
			DrawLine(spriteBatch, new Vector2(Position.X, Position.Y + Position.Height), new Vector2(Position.X, Position.Y));
			spriteBatch.End();

			base.Draw(gameTime);
		}*/

		protected void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end)
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
