using UnityEngine;
using System.Collections;
using System.Collections.Generic;

internal class UIManager
{
	#region Properties
	internal LoadingPanel loadingPanel;
	private Dictionary<string, Panel> _mapping;
	private static UIManager s_instance;
	#endregion
	
	internal static UIManager Instance
	{
		get
		{
			if(s_instance == null)
				s_instance = new UIManager();
			
			return s_instance;
		}
	}
	
	private UIManager()
	{
		_mapping = new Dictionary<string, Panel> ();
	}
	
	internal void Register(string a_key, Panel a_panel)
	{
		if (!_mapping.ContainsKey (a_key))
		{
			_mapping.Add (a_key, a_panel);
		}
		else
		{
			Debug.LogWarning("Same panel registered twice.");
		}
	}
	
	internal void Unregister(string a_key)
	{
		if (_mapping.ContainsKey (a_key))
		{
			_mapping.Remove(a_key);
		}
		else
		{
			Debug.LogWarning("No panel registered with this key : " + a_key);
		}
	}

	internal Panel GetPanel(string a_key)
	{
		if (_mapping.ContainsKey (a_key))
		{
			return _mapping[a_key];
		}

		Debug.LogWarning("No panel registered with this key : " + a_key);
		return null;
	}

	internal void HideAllPanels()
	{
		foreach (Panel each in _mapping.Values)
		{
			if(each.state != Panel.EState.Hidden && each.state != Panel.EState.Hidding)
				each.Hide();
		}
	}
}
