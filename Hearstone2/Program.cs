using System.Collections.Generic;
using System.Linq;
using Hearstone2.Core;
using Hearstone2.Core.Cards;
using Hearstone2.Core.Cards.Mage;
using Hearstone2.Core.Cards.Neutral;
using Hearstone2.Core.Players;

namespace Hearstone2
{
	class Program
	{
		static void Main(string[] args)
		{
		    var table = new Table(
		        new Druid
		            {
		                Deck = new List<Card> {new BluegillWarrior()}
		            },
		        new Mage
		            {
		                Deck = new List<Card> {new Fireball()}
		            });

			for (int i = 0; i < 10; i++)
			{
				PlayerTurn(table.Player1);
				PlayerTurn(table.Player2);

				table.Cleanup();
			}
		}

	    private static void PlayerTurn(Player player)
	    {
			player.GainMana();
            player.DrawCard();

	        var firstCard = player.Hand.FirstOrDefault();

			if (firstCard == null || !firstCard.CanPlay())
			{
				return;
			}

            if(firstCard is Minion)
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
                    ((IMinionTargetSpell) firstCard).Play(target);
                }
            }
	    }
	}
}
