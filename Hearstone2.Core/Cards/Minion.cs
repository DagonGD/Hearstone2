namespace Hearstone2.Core.Cards
{
	public abstract class Minion : Card
	{
		public abstract int Damage { get; }
		public abstract int Health { get; }
		public int CurrentHealth { get; private set; }

		public Minion()
		{
			CurrentHealth = Health;
		}

		public void DealDamage(int damage)
		{
			CurrentHealth -= damage;
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
