using UnityEngine;
using System.Collections;

internal enum EInputKey
{
	None,
	A,
	B,
	X,
	Y
}

internal class EventButton : MonoBehaviour
{
	#region Inspector Properties
	public string eventKey = "";
	public EInputKey inputKey = EInputKey.None;
	public UILabel keyLabel = null;
	#endregion

	protected virtual void Awake()
	{
		if (keyLabel != null)
		{
			keyLabel.text = inputKey.ToString();
		}
	}

	protected virtual void OnClick()
	{
		EventManager.Instance.FireEvent (eventKey);
	}

	void Update()
	{
		if(inputKey != EInputKey.None && Input.GetButtonDown(inputKey.ToString()))
		{
			OnClick();
		}
	}
}
