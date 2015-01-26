﻿using UnityEngine;
using System.Collections;

internal class RequestLevelButton : MonoBehaviour
{
	#region Inspector Properties
	public int levelIndex = 0;
	public EInputKey inputKey = EInputKey.None;
	#endregion

	protected virtual void OnClick()
	{
		EventParameter param = new EventParameter ();
		param.data = levelIndex;
		EventManager.Instance.FireEvent ("RequestLevel", param);
	}

	void Update()
	{
		if(inputKey != EInputKey.None && Input.GetButtonDown(inputKey.ToString()))
		{
			OnClick();
		}
	}
}
