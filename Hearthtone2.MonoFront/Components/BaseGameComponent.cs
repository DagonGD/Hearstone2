using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront.Components
{
	public abstract class BaseGameComponent: DrawableGameComponent
	{
		public abstract int Width { get; }
		public abstract int Height { get; }

		private readonly Rectangle _position;
		private MouseState _oldMouseState;

		protected BaseGameComponent(Game game, Point position)
			: base(game)
		{
			_position = new Rectangle(position.X, position.Y, Width, Height);
		}

		public override void Initialize()
		{
			_oldMouseState=new MouseState();

			base.Initialize();
		}

		public override void Update(GameTime gameTime)
		{
			var newMouseState = Mouse.GetState();

			if (_position.Contains(newMouseState.Position))
			{
				OnMouseOver();

				if (newMouseState.LeftButton == ButtonState.Pressed && _oldMouseState.LeftButton == ButtonState.Released)
				{
					OnClick();
				}

				if (newMouseState.RightButton == ButtonState.Pressed && _oldMouseState.RightButton == ButtonState.Released)
				{
					OnRightClick();
				}
			}

			base.Update(gameTime);
		}

		public virtual void OnMouseOver()
		{
			
		}

		public virtual void OnClick()
		{

		}

		public virtual void OnRightClick()
		{

		}
	}
}
