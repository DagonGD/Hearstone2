using System;
using System.Collections.Generic;
using Hearstone2.Core.Cards.Druid;
using Hearstone2.Core.Cards.Mage;
using Hearstone2.Core.Cards.Neutral;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Content
{
	public class CardFaceStorage
	{
		private readonly Hearthtone2Game _game;
		private readonly Dictionary<Type, Texture2D> _cardFaces;

		public CardFaceStorage(Hearthtone2Game game)
		{
			_game = game;
			_cardFaces = new Dictionary<Type, Texture2D>();
		}

		public void LoadContent()
		{
            _cardFaces.Add(typeof(HealingTouch), _game.Content.Load<Texture2D>("Heroes\\Druid\\Cards\\HealingTouch"));
            _cardFaces.Add(typeof(IronbarkProtector), _game.Content.Load<Texture2D>("Heroes\\Druid\\Cards\\IronbarkProtector"));
            _cardFaces.Add(typeof(Swipe), _game.Content.Load<Texture2D>("Heroes\\Druid\\Cards\\Swipe"));
            _cardFaces.Add(typeof(WildGrowth), _game.Content.Load<Texture2D>("Heroes\\Druid\\Cards\\WildGrowth"));

            _cardFaces.Add(typeof(ArcaneExplosion), _game.Content.Load<Texture2D>("Heroes\\Mage\\Cards\\ArcaneExplosion"));
            _cardFaces.Add(typeof(ArcaneIntellect), _game.Content.Load<Texture2D>("Heroes\\Mage\\Cards\\ArcaneIntellect"));
            _cardFaces.Add(typeof(Fireball), _game.Content.Load<Texture2D>("Heroes\\Mage\\Cards\\Fireball"));
            _cardFaces.Add(typeof(MirrorImage), _game.Content.Load<Texture2D>("Heroes\\Mage\\Cards\\MirrorImage"));
            _cardFaces.Add(typeof(MirrorImages), _game.Content.Load<Texture2D>("Heroes\\Mage\\Cards\\MirrorImages"));


			_cardFaces.Add(typeof(BluegillWarrior), _game.Content.Load<Texture2D>("Heroes\\Neutral\\Cards\\BluegillWarrior"));
		}

		public Texture2D GetCardFace(Type type)
		{
			return _cardFaces.ContainsKey(type) ? _cardFaces[type] : null;
		}
	}
}
