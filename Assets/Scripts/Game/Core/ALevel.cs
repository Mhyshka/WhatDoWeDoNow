using UnityEngine;
using System.Collections;

internal class ALevel : MonoBehaviour
{
	internal enum EState
	{
		Loading,
		Intro,
		GamePlay,
		Result,
		Exit
	}
	#region Inspector Properties

	#endregion

	#region Properties
	private float _loadingTimeRemaining = 0f;
	protected EState _state;
	#endregion
	
	// Use this for initialization
	void Awake()
	{
		LoadingEnter ();
		RegisterForEvents ();
	}
	
	#region Updates
	void Update ()
	{
		switch (_state)
		{
			case EState.Loading:
			UpdateLoading();
			break;

			case EState.Intro:
			UpdateIntro();
			break;

			case EState.GamePlay:
			UpdateGameplay();
			break;

			case EState.Result:
			UpdateResult();
			break;
		}
	}
	#endregion

	#region Loading
	private const float s_LOADING_DURATION = 1.0f;
	protected void LoadingEnter()
	{
		_state = EState.Loading;
		_loadingTimeRemaining = s_LOADING_DURATION;
	}


	protected virtual void UpdateLoading()
	{
		if (!Application.isLoadingLevel)
		{
			if(_loadingTimeRemaining <= 0f)
			{
				LoadingExit();
				IntroEnter();
			}
			else
			{
				_loadingTimeRemaining -= Time.deltaTime;
			}
		}
	}

	protected void LoadingExit()
	{
		_loadingTimeRemaining = 0f;
		UIManager.Instance.loadingPanel.Hide();
	}
	#endregion


	#region Intro
	protected virtual void IntroEnter()
	{
		Debug.Log("Intro Enter");
		_state = EState.Intro;
	}

	protected virtual void UpdateIntro()
	{
		IntroExit ();
	}

	protected virtual void IntroExit()
	{
		Debug.Log("Intro Exit");
		GameplayEnter ();
	}
	#endregion

	#region GamePlay
	protected virtual void GameplayEnter()
	{
		Debug.Log("GamePlay Enter");
		_state = EState.GamePlay;
	}

	protected virtual void UpdateGameplay()
	{

	}

	protected virtual void GameplayExit()
	{
		Debug.Log("GamePlay Exit");
		ResultEnter ();
	}
	#endregion

	#region Result
	protected virtual void ResultEnter()
	{
		Debug.Log("Result Enter");
		_state = EState.Result;
	}

	protected virtual void UpdateResult()
	{
	}

	protected virtual void ResultExit()
	{
		Debug.Log("Result Exit");
		_state = EState.Exit;
		Exit();
	}
	#endregion

	#region Event Management
	protected virtual void RegisterForEvents()
	{
		EventManager.Instance.RegisterForEvent("RequestLevel",OnRequestLevel);
	}
	
	protected virtual void UnregisterForEvents()
	{
		EventManager.Instance.UnregisterForEvent("RequestLevel",OnRequestLevel);
	}
	
	internal virtual void OnRequestLevel(EventParameter a_param)
	{
	}
	#endregion

	protected virtual void Exit()
	{
		UnregisterForEvents();
	}
}
