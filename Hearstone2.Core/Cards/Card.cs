namespace Hearstone2.Core.Cards
{
	/// <summary>
	/// Card in hand or on table
	/// </summary>
	public abstract class Card : ManaCostCard
	{
		/// <summary>
		/// To play any card we need to spend mana and remove this card from hand
		/// </summary>
		public override void Play()
		{
			Owner.Hand.Remove(this);

			base.Play();
		}
	}
}
