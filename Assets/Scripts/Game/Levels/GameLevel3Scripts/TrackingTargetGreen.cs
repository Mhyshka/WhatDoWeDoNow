using UnityEngine;
using System.Collections;

public class TrackingTargetGreen : TrackingTarget
{
	public TrackingTarget mNextTarget = null;


	internal override TrackingTarget GetNextTarget()
	{
		return mNextTarget;
	}
}
