using Hearstone2.Core.Classes;

namespace Hearstone2.Core
{
	public class Table
	{
		public Class Player1 { get; set; }
		public Class Player2 { get; set; }

	    public Table(Class player1, Class player2)
	    {
	        Player1 = player1;
	        Player1.Opponent = player2;

	        Player2 = player2;
	        player2.Opponent = player1;
	    }

		public void Cleanup()
		{
			Player1.PlacedMinions.RemoveAll(m => m.Health <= 0);
			Player2.PlacedMinions.RemoveAll(m => m.Health <= 0);
		}
	}
}
