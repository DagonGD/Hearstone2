using Hearstone2.Core.Cards.Mage;
using Hearstone2.Core.Cards.Neutral;

namespace Hearstone2
{
	class Program
	{
		static void Main(string[] args)
		{
			var bluegillWarrior = new BluegillWarrior();
			var fireball = new Fireball();
			fireball.Play(bluegillWarrior);
		}
	}
}
