using System;
using System.Collections.Generic;
using Hearstone2.Core.Classes;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Content
{
    public class AbilityStorage
    {
        private readonly Hearthtone2Game _game;
        private readonly Dictionary<Type, Texture2D> _abilities;

        public AbilityStorage(Hearthtone2Game game)
        {
            _game = game;
            _abilities = new Dictionary<Type, Texture2D>();
        }

        public void LoadContent()
        {
            _abilities.Add(typeof(Druid), _game.Content.Load<Texture2D>("Classes\\Druid\\Ability"));
            _abilities.Add(typeof(Mage), _game.Content.Load<Texture2D>("Classes\\Mage\\Ability"));
        }

        public Texture2D GetAbility(Type type)
        {
            return _abilities.ContainsKey(type) ? _abilities[type] : null;
        }
    }
}
