using Hearstone2.Core.Players;

namespace Hearstone2.Core
{
	public class Table
	{
		public Player Player1 { get; set; }
		public Player Player2 { get; set; }

		public void Cleanup()
		{
			Player1.PlacedMinions.RemoveAll(m => m.CurrentHealth <= 0);
			Player2.PlacedMinions.RemoveAll(m => m.CurrentHealth <= 0);
		}
	}
}
