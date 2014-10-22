using System.Collections.Generic;
using System.Linq;
using Hearstone2.Core;
using Hearstone2.Core.Cards;
using Hearstone2.Core.Cards.Mage;
using Hearstone2.Core.Cards.Neutral;
using Hearstone2.Core.Players;

namespace Hearthtone2.MonoFront
{
	public class GameObjects
	{
		public Table Table { get; set; }

		public void Init()
		{
			Table = new Table(
				new Druid
				{
					Deck = new List<Card> { new BluegillWarrior() }
				},
				new Mage
				{
					Deck = new List<Card> { new Fireball() }
				});
		}

		public void Turn()
		{
			PlayerTurn(Table.Player1);
			Table.Cleanup();
			PlayerTurn(Table.Player2);
			Table.Cleanup();
		}

		private void PlayerTurn(Player player)
		{
			player.GainMana();
			player.DrawCard();

			var firstCard = player.Hand.FirstOrDefault();

			if (firstCard == null || !firstCard.CanPlay())
			{
				return;
			}

			if (firstCard is Minion)
			{
				firstCard.Play();
				return;
			}

			if (firstCard is ISpelWithoutTarget)
			{
				((ISpelWithoutTarget)firstCard).Play();
				return;
			}

			if (firstCard is IMinionTargetSpell)
			{
				var target = player.Opponent.PlacedMinions.FirstOrDefault();

				if (target != null)
				{
					((IMinionTargetSpell)firstCard).Play(target);
				}
			}
		}
	}
}
