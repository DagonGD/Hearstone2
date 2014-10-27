using Hearstone2.Core.Heroes;

namespace Hearstone2.Core
{
	public class Table
	{
		public Hero Player1 { get; set; }
		public Hero Player2 { get; set; }
		public Hero CurrentPlayer { get; private set; }

	    public Table(Hero player1, Hero player2)
	    {
	        Player1 = player1;
	        Player1.Opponent = player2;

	        Player2 = player2;
	        player2.Opponent = player1;

		    CurrentPlayer = Player1;
	    }

		public void Cleanup()
		{
			Player1.PlacedMinions.RemoveAll(m => m.Health <= 0);
			Player2.PlacedMinions.RemoveAll(m => m.Health <= 0);
		}

		public void NextPlayer()
		{
			CurrentPlayer = CurrentPlayer.Opponent;
		}
	}
}
