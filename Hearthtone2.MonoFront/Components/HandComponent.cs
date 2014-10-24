using Hearstone2.Core.Classes;
using Microsoft.Xna.Framework;

namespace Hearthtone2.MonoFront.Components
{
	public class HandComponent: DrawableGameComponent
	{
		private readonly Game _game;
		private readonly Class _player;
		private readonly Point _position;

		public HandComponent(Game game, Class player, Point position)
			: base(game)
		{
			_game = game;
			_player = player;
			_position = position;
		}

		public override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}
	}
}
