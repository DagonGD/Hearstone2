namespace Hearstone2.Core.Cards
{
	public abstract class Minion : Card
	{
		public const int MaxMinionsOnTable = 7;

		public abstract int BaseDamage { get; }
		public abstract int BaseHealth { get; }
		public int Health { get; private set; }
        public int Damage { get; private set; }

		public Minion()
		{
			Health = BaseHealth;
		    Damage = BaseDamage;
		}

		public void DealDamage(Minion target)
		{
			target.ReceiveDamage(Damage);
		}

		public void ReceiveDamage(int damage)
		{
			Health -= damage;
		}

		/// <summary>
		/// To play minion we need to place it on the table
		/// </summary>
		public override void Play()
		{
			if (Owner.PlacedMinions.Count >= MaxMinionsOnTable)
			{
				throw new NoSpaceOnTableException();
			}

			Owner.PlacedMinions.Add(this);
			base.Play();
		}

		/// <summary>
		/// To play minion you need to have less then 7 minions on the table
		/// </summary>
		/// <returns></returns>
		public override bool CanPlay()
		{
			return base.CanPlay() && Owner.PlacedMinions.Count < MaxMinionsOnTable;
		}

		#region Mechanics
		public virtual void BattleCry()
		{

		}
		public virtual void DeathRattle()
		{

		}
		public virtual bool IsTaunt { get { return false; } }
		public virtual bool IsCharge { get { return false; } }
		#endregion
	}
}
