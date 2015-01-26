using UnityEngine;
using System.Collections;

internal class MenuLevel : ALevel
{
	#region Inspector Properties
	public LevelSelectionPanel levelSelectionPanel = null; 
	public float inputKeyRepeat = 0.2f;
	#endregion
	
	#region Properties
	private float _keyRepeatTimeRemaining = 0f;
	#endregion

	protected override void IntroEnter ()
	{
		base.IntroEnter ();
		levelSelectionPanel.Show();
	}

	protected override void UpdateGameplay()
	{
		base.UpdateGameplay ();

		if (_keyRepeatTimeRemaining <= 0f)
		{
			if (Input.GetAxis ("Horizontal") >= 1.0f)
			{
				levelSelectionPanel.levelGrid.NextIndex ();
				_keyRepeatTimeRemaining = inputKeyRepeat;
			} 
			else if (Input.GetAxis ("Horizontal") <= -1.0f)
			{
				levelSelectionPanel.levelGrid.PreviousIndex ();
				_keyRepeatTimeRemaining = inputKeyRepeat;
			}
			else if (Input.GetAxis ("Vertical") >= 1.0f)
			{
				levelSelectionPanel.levelGrid.PreviousRow ();
				_keyRepeatTimeRemaining = inputKeyRepeat;
			} 
			else if (Input.GetAxis ("Vertical") <= -1.0f)
			{
				levelSelectionPanel.levelGrid.NextRow();
				_keyRepeatTimeRemaining = inputKeyRepeat;
			}
		}
		else
			_keyRepeatTimeRemaining -= Time.deltaTime;

		if (Input.GetButtonDown ("X"))
		{
			Debug.Log("Button X");
			GameManager.Instance.levelIndex = levelSelectionPanel.levelGrid.SelectedIndex;
			Exit();
		} 
	}

	protected override void Exit()
	{
		GameLevelData level = GameManager.Instance.levels[GameManager.Instance.levelIndex];
		GameManager.Instance.RequestLevel(level.sceneName);
	}

	#region Event Management
	internal override void OnRequestLevel(EventParameter a_param)
	{
		GameManager.Instance.levelIndex = (int)a_param.data;
		Exit();
	}
	#endregion


}
