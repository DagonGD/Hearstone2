using Hearstone2.Core.Heroes;
using Hearthtone2.MonoFront.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Components
{
    public class ManaCrystalsComponent : BaseOwnedComponent
    {
        public ManaCrystalsComponent(Hearthtone2Game game, Hero owner, Point position) 
            : base(game, owner, new Rectangle(position.X, position.Y, MiscImageStorage.ManaCrystalWidth*10, MiscImageStorage.ManaCrystalHeight))
        {
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            spriteBatch.Begin();
            for (var i = 0; i < Owner.MaxMana; i++)
            {
                var color = i < Owner.Mana ? Color.White : Color.Gray;
                spriteBatch.Draw(Game.MiscImageStorage.GetManaCrystalImage(), new Rectangle(Position.X+i * MiscImageStorage.ManaCrystalWidth, Position.Y, MiscImageStorage.ManaCrystalWidth, MiscImageStorage.ManaCrystalHeight), color);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
