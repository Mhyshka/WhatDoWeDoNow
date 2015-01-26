using UnityEngine;
using System.Collections;

public class TrackingTargetRed : TrackingTarget
{
	protected override void OnTriggerEnter()
	{
		EventManager.Instance.FireEvent ("LevelComplete");
	}
}
