using UnityEngine;
using System.Collections;

internal class LoadingPanel : Panel
{
	protected override void Awake ()
	{
		UIManager.Instance.loadingPanel = this;
		if (hideOnLoad)
			OnHidden ();
		else
			OnShown ();
	}

	protected override void OnDestroy ()
	{
		UIManager.Instance.loadingPanel = null;
	}

	internal override void Show()
	{
		gameObject.SetActive(true);
		tweensIn.SampleForward ();
		state = EState.Showing;
		OnTransitionComplete ();
	}

}
