namespace Hearstone2.Core.Cards.Neutral
{
	public class BluegillWarrior : Minion
	{
		public override string Title
		{
			get { return "Bluegill Warrior"; }
		}

		public override int ManaCost
		{
			get { return 2; }
		}

		public override int BaseDamage
		{
			get { return 2; }
		}

		public override int BaseHealth
		{
			get { return 1; }
		}

		public override bool IsCharge { get { return true; } }
	}
}
