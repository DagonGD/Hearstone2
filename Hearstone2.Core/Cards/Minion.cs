namespace Hearstone2.Core.Cards
{
	public abstract class Minion : Card
	{
		public abstract int BaseDamage { get; }
		public abstract int BaseHealth { get; }
		public int Health { get; private set; }
        public int Damage { get; private set; }

		public Minion()
		{
			Health = BaseHealth;
		    Damage = BaseDamage;
		}

		public void DealDamage(int damage)
		{
			Health -= damage;
		}

		/// <summary>
		/// To play minion we need to place it on the table
		/// </summary>
		public override void Play()
		{
			Owner.PlacedMinions.Add(this);
			base.Play();
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
