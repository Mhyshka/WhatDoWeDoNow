using UnityEngine;
using System.Collections;

internal class Panel : MonoBehaviour
{
	internal enum EState
	{
		Hidden,
		Showing,
		Shown,
		Hidding
	}

	#region Inspector Properties
	public TweenerGroup tweensIn = null;
	public bool hideOnLoad = true;
	#endregion

	#region Properties
	internal EState state = EState.Hidden;
	#endregion

	protected virtual void Awake()
	{
		UIManager.Instance.Register (gameObject.name, this);
		if (hideOnLoad)
			OnHidden ();
		else
			OnShown ();
	}

	protected virtual void OnDestroy()
	{
		UIManager.Instance.Unregister (gameObject.name);
	}

	internal virtual void Hide()
	{
		if (state == EState.Shown)
		{
			state = EState.Hidding;
			tweensIn.PlayReverse ();
		}
		else if (state == EState.Showing)
		{
			state = EState.Hidding;
			tweensIn.Toggle();
		}
	}
	
	internal virtual void Show()
	{
		if (state == EState.Hidden)
		{
			state = EState.Showing;
			gameObject.SetActive(true);
			tweensIn.PlayForward ();
		}
		else if (state == EState.Hidding)
		{
			state = EState.Showing;
			tweensIn.Toggle();
		}
	}

	public void OnTransitionComplete()
	{
		if (state == EState.Showing || state == EState.Hidden)
		{
			OnShown();
		}
		else if (state == EState.Hidding || state == EState.Shown)
		{
			OnHidden();
		}
	}

	internal virtual void OnShown()
	{
		state = EState.Shown;
	}

	internal virtual void OnHidden()
	{
		state = EState.Hidden;
		gameObject.SetActive (false);
	}
}
