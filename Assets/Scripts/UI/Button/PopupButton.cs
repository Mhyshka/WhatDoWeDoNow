using UnityEngine;
using System.Collections;

internal class PopupButton : EventButton
{
	#region Inspector Properties
	public Popup popup = null;
	#endregion



	protected override void OnClick()
	{
		
		popup.Hide();

		EventParameter param = new EventParameter ();
		param.data = popup;
		EventManager.Instance.FireEvent (eventKey,param);
	}
}
