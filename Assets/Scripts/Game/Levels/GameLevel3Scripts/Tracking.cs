using UnityEngine;
using System.Collections;
using System;

internal class Tracking : MonoBehaviour
{
	#region Properties
	public TrackingTarget mFirstTarget = null;
	#endregion


	private TrackingTarget mNextPos = null;


	void Awake ()
	{
		EventManager.Instance.RegisterForEvent ("ResetLevel",ResetLevel);
		EventManager.Instance.RegisterForEvent ("TrackingReached",OnTrackingReached);
	}


	void OnDestroy ()
	{
		EventManager.Instance.UnregisterForEvent ("ResetLevel",ResetLevel);
		EventManager.Instance.UnregisterForEvent ("Green1Trigger",OnTrackingReached);
	}


	internal void OnTrackingReached (EventParameter a_param)
	{
		TrackingTarget target = a_param.data as TrackingTarget;
		if (target == mNextPos) 
		{
			mNextPos = target.GetNextTarget();
		}
	}


	internal void ResetLevel (EventParameter a_param)
	{
		mNextPos = mFirstTarget;
	}

}
