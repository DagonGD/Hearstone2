﻿using System.Collections.Generic;
using System.Linq;
using Hearstone2.Core.Heroes;
using Microsoft.Xna.Framework;

namespace Hearthtone2.MonoFront.Components
{
	public class BaseCardGameComponent : BaseOwnedComponent
	{
		protected List<PlacedCard> PlacedCards;

		public BaseCardGameComponent(Hearthtone2Game game, Hero owner, Rectangle position)
			: base(game, owner, position)
		{
		}

		public void InitCards(List<PlacedCard> placedCards)
		{
			PlacedCards = placedCards;
		}

		public override void OnClick(Point position)
		{
			var targetCard = PlacedCards.FirstOrDefault(c => c.Position.Contains(position));

			if (targetCard != null)
			{
				OnCardClick(targetCard);
			}
		}

		public override void OnMouseOver(Point position)
		{
			var targetCard = PlacedCards.FirstOrDefault(c => c.Position.Contains(position));

			if (targetCard != null)
			{
				OnCardOver(targetCard);
			}
		}

		public virtual void OnCardClick(PlacedCard card)
		{
			
		}

		public virtual void OnCardOver(PlacedCard card)
		{

		}
	}
}
