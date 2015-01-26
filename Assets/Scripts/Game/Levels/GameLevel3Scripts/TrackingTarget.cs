using UnityEngine;
using System.Collections;

public class TrackingTarget : MonoBehaviour
{
	protected virtual void OnTriggerEnter()
	{
		EventParameter arg = new EventParameter();
		arg.data = this;
		EventManager.Instance.FireEvent ("TrackingReached", arg);
	}


	internal virtual TrackingTarget GetNextTarget ()
	{
		return null;
	}
}
