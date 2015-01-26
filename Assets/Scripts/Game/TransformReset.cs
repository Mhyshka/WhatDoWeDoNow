using UnityEngine;
using System.Collections;

internal class TransformReset : MonoBehaviour
{
	#region Inspector Properties
	#endregion
	
	#region Properties
	protected Vector3 _basePos;
	protected Quaternion _baseRot;
	//protected Vector3 _baseScale;
	#endregion
	
	void Awake()
	{
		_basePos = transform.position;
		_baseRot = transform.rotation;
		//_baseScale = transform.lossyScale;
		RegisterForEvents();
	}
	
	void OnDestroy()
	{
		UnregisterForEvents();
	}
	
	#region Event Management
	internal void RegisterForEvents()
	{
		EventManager.Instance.RegisterForEvent ("ResetLevel", OnReset);
	}
	
	internal void UnregisterForEvents()
	{
		EventManager.Instance.UnregisterForEvent ("ResetLevel", OnReset);
	}
	
	internal virtual void OnReset(EventParameter args = null)
	{
		transform.position = _basePos;
		transform.rotation = _baseRot;
		//transform.lossyScale = _baseScale;
	}
	#endregion
}
