using Hearstone2.Core.Cards;
using Hearstone2.Core.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Components
{
    public class HeroAbilityComponent : BaseOwnedComponent
    {
        public const int Width = 90;
        public const int Height = 100;

        private Color _color=Color.White;

        public HeroAbilityComponent(Hearthtone2Game game, Hero owner, Point position)
			: base(game, owner, new Rectangle(position.X, position.Y, Width, Height))
        {
        }

        public override void OnMouseOver(Point position)
		{
			if (Game.CurrentGameMode == GameMode.SelectCard && Game.Table.CurrentPlayer == Owner)
			{
				_color = Owner.HeroAbility.CanPlay() ? Color.LightGreen : Color.Red;
			}
			else
			{
				_color = Color.White;
			}
		}

		public override void OnMouseOutside(Point position)
		{
			_color = Color.White;
		}

		public override void OnClick(Point position)
		{
			if (Owner.HeroAbility is IMinionTargetSpell || Owner.HeroAbility is IHeroTargetSpell)
			{
				Game.SelectTargetFor(new PlacedCard { Card = Owner.HeroAbility, Position = Position, Color = Color.White });
			}
			else if (Owner.HeroAbility is ISpellWithoutTarget)
			{
				((ISpellWithoutTarget)Owner.HeroAbility).Play();
			}

			base.OnClick(position);
		}

        public override void Draw(GameTime gameTime)
        {
			var spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            spriteBatch.Begin();
			spriteBatch.Draw(Game.AbilityStorage.GetAbility(Owner.GetType()), Position, _color);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
