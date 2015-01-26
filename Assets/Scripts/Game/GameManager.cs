using UnityEngine;
using System.Collections;
using System.Collections.Generic;

internal class GameManager
{
	#region Properties
	internal List<GameLevelData> levels = new List<GameLevelData>();
	internal int levelIndex = 0;
	private static GameManager s_instance;
	#endregion

	internal static GameManager Instance
	{
		get
		{
			if(s_instance == null)
				s_instance = new GameManager();
			
			return s_instance;
		}
	}

	internal void DoNothing()
	{

	}
	
	private GameManager()
	{

	}


	internal void NextLevel()
	{
		levelIndex++;
		Debug.LogWarning("levelIndex " + levelIndex);
		Debug.LogWarning("levels.Count  " + levels.Count );

		if (levels.Count > levelIndex) 
		{
			RequestLevel(levels[levelIndex].sceneName);
		}
	}

	internal void RequestLevel(string a_sceneName)
	{
		UIManager.Instance.loadingPanel.Show();
		Application.LoadLevelAsync (a_sceneName);
	}
}