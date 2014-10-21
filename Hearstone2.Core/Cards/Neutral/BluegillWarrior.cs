namespace Hearstone2.Core.Cards.Neutral
{
	public class BluegillWarrior : Minion
	{
		public override string Title
		{
			get { return "Bluegill Warrior"; }
		}

		public override int Damage
		{
			get { return 2; }
		}

		public override int Health
		{
			get { return 1; }
		}

		public override bool IsCharge { get { return true; } }
	}
}
