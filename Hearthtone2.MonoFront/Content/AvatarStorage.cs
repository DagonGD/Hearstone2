using System;
using System.Collections.Generic;
using Hearstone2.Core.Heroes.Druid;
using Hearstone2.Core.Heroes.Mage;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Content
{
    public class AvatarStorage
    {
        private readonly Hearthtone2Game _game;
        private readonly Dictionary<Type, Texture2D> _avatars;

        public AvatarStorage(Hearthtone2Game game)
        {
            _game = game;
            _avatars = new Dictionary<Type, Texture2D>();
        }

        public void LoadContent()
        {
            _avatars.Add(typeof(Druid), _game.Content.Load<Texture2D>("Classes\\Druid\\Avatar"));
            _avatars.Add(typeof(Mage), _game.Content.Load<Texture2D>("Classes\\Mage\\Avatar"));
        }

        public Texture2D GetAvatar(Type type)
        {
            return _avatars.ContainsKey(type) ? _avatars[type] : null;
        }
    }
}
