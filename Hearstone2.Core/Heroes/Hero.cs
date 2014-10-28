using System.Collections.Generic;
using System.Linq;
using Hearstone2.Core.Cards;

namespace Hearstone2.Core.Heroes
{
	public abstract class Hero
	{
		public List<Card> Hand { get; private set; }
		public List<Card> Deck { get; set; }
		public List<Minion> PlacedMinions { get; private set; }
        public Hero Opponent { get; set; }
        public int Mana { get; set; }
		public int MaxMana { get; set; }
        public int Health { get; private set; }

	    protected Hero()
		{
			Hand = new List<Card>();
			Deck = new List<Card>();
			PlacedMinions = new List<Minion>();
			MaxMana = 0;
		    Health = 30;
		}

		public abstract HeroAbility HeroAbility { get; }

		public bool IsAlive
		{
			get { return Health > 0; }
		}

		public void GainMana()
		{
		    if (MaxMana < 10)
		    {
		        MaxMana++;
		    }
		    Mana = MaxMana;
		}

		public void DrawCard()
		{
			var card = Deck.FirstOrDefault();

			if (card == null)
			{
				//TODO: Deal damage to player
				return;
			}

			card.Owner = this;
			Hand.Add(card);
			Deck.Remove(card);
		}

        public void RefreshMinions()
        {
            PlacedMinions.ForEach(m => m.Refresh());
        }

        public void ReceiveDamage(int damage)
        {
            Health -= damage;
        }

		public void Heal(int damage)
		{
			Health += damage;
		}

		public bool CanMinionBeATargetOfAttack(Minion target)
		{
			if (target.IsTaunt)
			{
				return true;
			}

			var taunts = PlacedMinions.Where(c => c.IsTaunt).ToList();
			return !taunts.Any();
		}
	}
}
