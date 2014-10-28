using Hearstone2.Core.Cards;
using Hearstone2.Core.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Components
{
    public class HeroAbilityComponent : BaseGameComponent
    {
        public const int Width = 90;
        public const int Height = 100;

        private readonly Hero _player;
        private Color _color=Color.White;

        public HeroAbilityComponent(Hearthtone2Game game, Hero player, Point position)
			: base(game, new Rectangle(position.X, position.Y, Width, Height))
        {
            _player = player;
        }

        public override void OnMouseOver(Point position)
		{
			if (Game.CurrentGameMode == GameMode.SelectCard && Game.Table.CurrentPlayer == _player)
			{
				_color = _player.HeroAbility.CanPlay() ? Color.LightGreen : Color.Red;
			}
		}

		public override void OnClick(Point position)
		{
			if (_player.HeroAbility is IMinionTargetSpell || _player.HeroAbility is IHeroTargetSpell)
			{
				Game.CurrentlyPlayingCard = new PlacedCard { Card = _player.HeroAbility, Position = Position, Color = Color.White };
				Game.CurrentGameMode = GameMode.SelectTarget;
			}
			else if (_player.HeroAbility is ISpellWithoutTarget)
			{
				((ISpellWithoutTarget)_player.HeroAbility).Play();
			}

			base.OnClick(position);
		}

        public override void Draw(GameTime gameTime)
        {
			var spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            spriteBatch.Begin();
			spriteBatch.Draw(Game.AbilityStorage.GetAbility(_player.GetType()), Position, _color);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
