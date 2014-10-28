using Hearstone2.Core.Cards;
using Hearstone2.Core.Heroes;
using Hearthtone2.MonoFront.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Components
{
    public class HeroAvatarComponent : BaseOwnedComponent
    {
        public const int Width = 87;
        public const int Height = 100;

        public HeroAvatarComponent(Hearthtone2Game game, Hero owner, Point position)
			: base(game, owner, new Rectangle(position.X, position.Y, Width, Height))
        {
        }

		public override void OnClick(Point position)
		{
			if (Game.CurrentGameMode == GameMode.SelectTarget)
			{
				var heroTargetSpell = Game.CurrentlyPlayingCard.Card as IHeroTargetSpell;
				if (heroTargetSpell != null && Game.CurrentlyPlayingCard.Card.CanPlay())
				{
					heroTargetSpell.Play(Owner);
                    Game.Table.Cleanup();
					Game.ResetGameMode();
				}
				else
				{
					var minion = Game.CurrentlyPlayingCard.Card as Minion;
					if (minion != null && minion.CanFight)
					{
						minion.DealDamage(Owner);
						Game.ResetGameMode();
					}
				}
			}
		}

        public override void Draw(GameTime gameTime)
        {
			var spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            spriteBatch.Begin();
			spriteBatch.Draw(Game.AvatarStorage.GetAvatar(Owner.GetType()), Position, Owner.Health > 0 ? Color.White : Color.Red);
			spriteBatch.DrawString(Game.FontsStorage.GetFont(Font.Arial), Owner.Health.ToString(), new Vector2(Position.X, Position.Y), Color.White);
            
            if (Owner.Armor > 0)
            {
                spriteBatch.DrawString(Game.FontsStorage.GetFont(Font.Arial), Owner.Armor.ToString(), new Vector2(Position.X + Width-5, Position.Y), Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
