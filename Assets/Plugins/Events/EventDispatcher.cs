using System;
using System.Collections.Generic;

namespace CatPot.Framework.Messaging
{
	public class EventDispatcher
	{
		static EventDispatcher _instance;

		public static EventDispatcher Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new EventDispatcher();
				}

				return _instance;
			}
		}

		public delegate void EventDelegate<T>(T e) where T : GameEvent;

		readonly Dictionary<Type, Delegate> _delegates = new Dictionary<Type, Delegate>();

		public void AddListener<T>(EventDelegate<T> listener) where T : GameEvent
		{
			Delegate d;
			if (_delegates.TryGetValue(typeof(T), out d))
			{
				_delegates[typeof(T)] = Delegate.Combine(d, listener);
			}
			else
			{
				_delegates[typeof(T)] = listener;
			}
		}

		public void RemoveListener<T>(EventDelegate<T> listener) where T : GameEvent
		{
			Delegate d;
			if (_delegates.TryGetValue(typeof(T), out d))
			{
				Delegate currentDel = Delegate.Remove(d, listener);

				if (currentDel == null)
				{
					_delegates.Remove(typeof(T));
				}
				else
				{
					_delegates[typeof(T)] = currentDel;
				}
			}
		}

		public void Dispatch<T>(T e) where T : GameEvent
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}

			Delegate d;
			if (_delegates.TryGetValue(typeof(T), out d))
			{
				EventDelegate<T> callback = d as EventDelegate<T>;
				if (callback != null)
				{
					callback(e);
				}
			}
		}

        /*
         * A good practice would be to subscribe to an event type inside the OnEnable() method and unsubscribe in OnDisable() but there's this method
         * if you want to be nasty and clean up all the mess when leaving a scene or if you just want to subscribe with lambdas
         * 
         * Bear in mind that since this is a singleton it'll live throughout the whole execution of the game, though.
         */
		public void Clean()
		{
			foreach (Type t in _delegates.Keys)
			{
				_delegates[t] = null;
			}

			_delegates.Clear();
		}
	}
}