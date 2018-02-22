using UnityEngine;

namespace CatPot.Framework.Messaging
{
	public class GameEvent
	{
		public GameObject Sender { get; protected set; }

		public GameEvent(GameObject sender)
		{
			Sender = sender;
		}
	}
}