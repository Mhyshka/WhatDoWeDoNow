using UnityEngine;
using System.Collections;

public class TrackingTargetOrange : TrackingTarget {

	public TrackingTarget[] mNextTarget = null;
	
	
	internal override TrackingTarget GetNextTarget()
	{
		int index = Random.Range(0, mNextTarget.Length);
		return mNextTarget[index];
	}
}
