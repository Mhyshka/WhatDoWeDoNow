using UnityEngine;
using System.Collections;

internal class GameLevel : ALevel
{
	#region Inspector Properties
	public Player player = null;
	public Camera gameplayCamera = null;
	
	public bool displayInstructions = false;
	public string tutoTitle = "New Level";
	public string tutoDesc = "Look for an exit!";
	#endregion
	
	#region Properties
	protected bool _didWin = false;
	protected PlayPanel _playPanel;
	protected ResultPanel _resultPanel;
	
	protected TimerWidget Timer
	{
		get
		{
			return _playPanel.timer;
		}
	}
	protected RatingWidget Rating
	{
		get
		{
			return null;
		}
	}
	protected GameLevelData LevelData
	{
		get
		{
			return GameManager.Instance.levels[GameManager.Instance.levelIndex];
		}
	}
	#endregion
	
	#region Intro
	protected override void IntroEnter()
	{
		base.IntroEnter ();
		if (_playPanel == null)
			_playPanel = UIManager.Instance.GetPanel ("PlayPanel") as PlayPanel;
		_playPanel.Show ();
		
		if (_resultPanel == null)
			_resultPanel = UIManager.Instance.GetPanel ("ResultPanel") as ResultPanel;
		
		if(gameplayCamera != null)
			gameplayCamera.enabled = true;
		ResetLevel ();
	}
	#endregion
	
	#region Result
	protected override void ResultEnter ()
	{
		base.ResultEnter ();
		UIManager.Instance.HideAllPanels ();
		if (_didWin)
		{
			float newHighscore = LevelData.NewScore (Timer.TimeRemaining);
			int oldRating = LevelData.currentRating;
			int lRating = LevelData.GetRating (Timer.TimeRemaining);
			
			if(newHighscore != -1f)
			{
				_resultPanel.SetResult(Timer.TimeRemaining,lRating,Mathf.Clamp (lRating - oldRating,0,4),newHighscore);
			}
			else
			{
				_resultPanel.SetResult(Timer.TimeRemaining, lRating);
			}
			_resultPanel.Show();
		}
		else
		{
			Popup lLoose = UIManager.Instance.GetPanel("LosePopup") as Popup;
			
			lLoose.Show ();
		}
	}
	
	protected override void GameplayExit ()
	{
		base.GameplayExit ();
		
		_playPanel.Hide ();
	}
	#endregion
	
	#region Event Management
	protected override void RegisterForEvents ()
	{
		base.RegisterForEvents ();
		EventManager.Instance.RegisterForEvent ("TimesUp", OnTimeElapsed);
		EventManager.Instance.RegisterForEvent ("Lose", OnLose);
		EventManager.Instance.RegisterForEvent ("LevelComplete", OnLevelComplete);

		EventManager.Instance.RegisterForEvent ("Replay", OnReplay);
		EventManager.Instance.RegisterForEvent ("GoToMenu", OnGoToMenu);
		EventManager.Instance.RegisterForEvent ("NextLevel", OnRequestNextLevel);
	}
	
	protected override void UnregisterForEvents ()
	{
		base.UnregisterForEvents ();
		EventManager.Instance.UnregisterForEvent ("TimesUp", OnTimeElapsed);
		EventManager.Instance.RegisterForEvent ("Lose", OnLose);
		EventManager.Instance.UnregisterForEvent ("LevelComplete", OnLevelComplete);

		EventManager.Instance.UnregisterForEvent ("Replay", OnReplay);
		EventManager.Instance.UnregisterForEvent ("GoToMenu", OnGoToMenu);
		EventManager.Instance.UnregisterForEvent ("NextLevel", OnRequestNextLevel);
	}
	
	internal virtual void OnRequestNextLevel (EventParameter a_args)
	{
		_resultPanel.Hide();
		UnregisterForEvents ();
		GameManager.Instance.NextLevel ();
	}
	
	internal virtual void OnTimeElapsed(EventParameter a_args)
	{
		if (_state == EState.GamePlay)
		{
			Timer.enabled = false;
			_didWin = false;
			
			GameplayExit();
		}
	}

	
	internal virtual void OnLose(EventParameter a_args)
	{
		if (_state == EState.GamePlay)
		{
			Timer.enabled = false;
			_didWin = false;
			
			GameplayExit();
		}
	}
	
	internal virtual void OnLevelComplete(EventParameter a_args)
	{
		if (_state == EState.GamePlay)
		{
			_didWin = true;
			Timer.enabled = false;
			
			GameplayExit();
		}
	}
	
	internal virtual void OnReplay(EventParameter a_args)
	{
		IntroEnter ();
	}
	
	
	internal virtual void OnGoToMenu(EventParameter a_args)
	{	
		ResultExit ();
	}
	
	
	#endregion
	
	protected virtual void ResetLevel()
	{
		EventManager.Instance.FireEvent ("ResetLevel");
		
		if (displayInstructions)
		{
			Popup popup = UIManager.Instance.GetPanel ("Popup") as Popup;
			popup.SetCloseData (tutoTitle, tutoDesc);
			popup.Show();
		}
		else
		{
			player.EnableInput ();
		}
		Timer.SetTimer (LevelData.targetTime);
		Timer.enabled = true;
		_didWin = false;
		
	}
	
	
	protected override void Exit()
	{
		base.Exit ();
		
		GameManager.Instance.RequestLevel("Menu");
	}
}
