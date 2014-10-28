using Hearstone2.Core.Cards;
using Hearthtone2.MonoFront.Components;
using Hearthtone2.MonoFront.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hearthtone2.MonoFront.Drawings
{
    public class CardDrawer
    {
        private readonly Hearthtone2Game _game;

        public CardDrawer(Hearthtone2Game game)
        {
            _game = game;
        }

        public void Draw(PlacedCard card, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_game.CardFaceStorage.GetCardFace(card.Card.GetType()), card.Position, card.Color);

            var minion = card.Card as Minion;
            if (minion != null)
            {
                spriteBatch.Draw(_game.MiscImageStorage.GetEmptyCard(), card.Position, card.Color);

                spriteBatch.DrawString(_game.FontsStorage.GetFont(Font.Arial), minion.ManaCost.ToString(),
                                       new Vector2(card.Position.X + 20, card.Position.Y + 40), Color.Black);

                spriteBatch.DrawString(_game.FontsStorage.GetFont(Font.Arial), minion.Damage.ToString(),
                                       new Vector2(card.Position.X+20, card.Position.Y + PlacedCard.Height-40), Color.Black);

                spriteBatch.DrawString(_game.FontsStorage.GetFont(Font.Arial), minion.Health.ToString(),
                                       new Vector2(card.Position.X + PlacedCard.Width - 30,
                                                   card.Position.Y + PlacedCard.Height-40), Color.Black);
            }
        }
    }
}
