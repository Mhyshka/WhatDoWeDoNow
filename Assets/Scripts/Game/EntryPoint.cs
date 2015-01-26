using UnityEngine;
using System.Collections;

internal class EntryPoint : MonoBehaviour
{
	public string levelToLoad = "Menu";
	void Awake()
	{
		GameManager.Instance.DoNothing ();
		Application.LoadLevelAsync(levelToLoad);
	}
}