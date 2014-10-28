using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront.Components
{
	public abstract class BaseGameComponent: DrawableGameComponent
	{
		protected readonly Rectangle Position;
		private MouseState _oldMouseState;

		protected BaseGameComponent(Game game, Rectangle position)
			: base(game)
		{
			Position = position;
		}

		public override void Initialize()
		{
			_oldMouseState=new MouseState();

			base.Initialize();
		}

		public override void Update(GameTime gameTime)
		{
			var newMouseState = Mouse.GetState();

			if (Position.Contains(newMouseState.Position))
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
