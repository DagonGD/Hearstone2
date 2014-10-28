using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Content
{
	public class FontsStorage
	{
		private readonly Hearthtone2Game _game;
		private readonly Dictionary<Font, SpriteFont> _fonts;

		public FontsStorage(Hearthtone2Game game)
		{
			_game = game;
			_fonts = new Dictionary<Font, SpriteFont>();
		}

		public void LoadContent()
		{
			_fonts.Add(Font.Arial, _game.Content.Load<SpriteFont>("Fonts//Arial"));
		}

		public SpriteFont GetFont(Font font)
		{
			return _fonts.ContainsKey(font) ? _fonts[font] : null;
		}
	}
}
