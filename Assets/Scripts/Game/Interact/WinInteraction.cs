using UnityEngine;
using System.Collections;

internal class WinInteraction : Interactable
{
	internal override void OnInteraction ()
	{
		base.OnInteraction ();
		EventManager.Instance.FireEvent("LevelCompletion");
	}
}
