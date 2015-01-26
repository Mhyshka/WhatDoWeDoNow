using System.Collections;
							
internal class GameLevel1 : GameLevel
{
	protected override void RegisterForEvents ()
	{
		base.RegisterForEvents ();
		EventManager.Instance.RegisterForEvent ("ClosePopup", OnClosePopup);
	}

	protected override void UnregisterForEvents ()
	{
		base.UnregisterForEvents ();
		EventManager.Instance.UnregisterForEvent ("ClosePopup", OnClosePopup);
	}

	internal virtual void OnClosePopup (EventParameter a_args)
	{
		OnLevelComplete (null);
	}
}