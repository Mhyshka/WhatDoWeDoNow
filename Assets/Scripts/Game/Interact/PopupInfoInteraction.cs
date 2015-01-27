﻿using UnityEngine;
using System.Collections;

internal class PopupInfoInteraction : Interactable
{
	#region Inspector Properties
	public string title = "";
	public string description = "";
	public string closeText = "";
	#endregion

	internal override void OnInteraction ()
	{
		base.OnInteraction ();
		Popup popup;

		if (string.IsNullOrEmpty (title))
		{
			popup = UIManager.Instance.GetPanel("LittlePopup") as Popup;
			popup.SetCloseData (description);
		}
		else
		{
			popup = UIManager.Instance.GetPanel("Popup") as Popup;
			popup.SetCloseData (title, description);
		}

		if(!string.IsNullOrEmpty(closeText))
		{
			popup.SetButtonText(closeText);
		}

		popup.Show ();
	}
}
