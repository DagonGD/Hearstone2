namespace Hearstone2.Core.Cards
{
	public abstract class Minion : CardBase
	{
		public abstract int Damage { get; }
		public abstract int Health { get; }

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
