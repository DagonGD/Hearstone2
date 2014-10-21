using System;
using System.Collections.Generic;
using System.Linq;
namespace Hearstone2.Core.Cards.Druid
{
	public class IronbarkProtector : Minion
	{
		public override string Title
		{
			get { return "IronbarkProtector"; }
		}

		public override int Damage { get { return 8; } }
		public override int Health { get { return 8; } }

		public override bool IsTaunt
		{
			get { return true; }
		}
	}
}
