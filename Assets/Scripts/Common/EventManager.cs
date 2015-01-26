using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


internal class EventParameter
{
	internal System.Object data = null;
}

internal delegate void EventCallback(EventParameter a_eventParam);

internal class EventManager
{
	#region Properties
	private Dictionary<string, EventCallback> _mapping;
	private static EventManager s_instance;
	#endregion

	internal static EventManager Instance
	{
		get
		{
			if(s_instance == null)
				s_instance = new EventManager();

			return s_instance;
		}
	}

	private EventManager()
	{
		_mapping = new Dictionary<string, EventCallback> ();
	}

	internal void RegisterForEvent(string a_key, EventCallback a_callback)
	{
		if (!_mapping.ContainsKey (a_key))
		{
			_mapping.Add (a_key, a_callback);
		}
		else
		{
			_mapping[a_key] += a_callback;
		}
	}

	internal void UnregisterForEvent(string a_key, EventCallback a_callback)
	{
		if (_mapping.ContainsKey (a_key))
		{
			_mapping[a_key] -= a_callback;
		}
	}

	internal void FireEvent(string a_key, EventParameter a_eventParam = null)
	{
		if (_mapping.ContainsKey (a_key))
		{
			_mapping[a_key].Invoke(a_eventParam);
		}
		else
		{
			Debug.LogWarning("No event register on : " + a_key);
		}
	}
}
