using Hearstone2.Core.Players;

namespace Hearstone2.Core
{
	public class Table
	{
		public Player Player1 { get; set; }
		public Player Player2 { get; set; }

	    public Table(Player player1, Player player2)
	    {
	        Player1 = player1;
	        Player1.Opponent = player2;

	        Player2 = player2;
	        player2.Opponent = player1;
	    }

		public void Cleanup()
		{
			Player1.PlacedMinions.RemoveAll(m => m.CurrentHealth <= 0);
			Player2.PlacedMinions.RemoveAll(m => m.CurrentHealth <= 0);
		}
	}
}
