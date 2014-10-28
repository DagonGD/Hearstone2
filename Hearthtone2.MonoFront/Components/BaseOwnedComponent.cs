using Hearstone2.Core.Heroes;
using Microsoft.Xna.Framework;

namespace Hearthtone2.MonoFront.Components
{
	public class BaseOwnedComponent : BaseGameComponent
	{
		protected readonly Hero Owner;

		public BaseOwnedComponent(Hearthtone2Game game, Hero owner, Rectangle position) 
			: base(game, position)
		{
			Owner = owner;
		}
	}
}
