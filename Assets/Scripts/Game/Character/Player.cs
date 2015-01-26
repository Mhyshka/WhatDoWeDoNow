using UnityEngine;
using System.Collections;

internal class Player : MonoBehaviour
{
	#region Inspector Properties
	public EInputKey interactionKey = EInputKey.X;

	public CharacterController controller = null;
	public MouseLook look = null;
	public CharacterMotor motor = null;
	public Camera gameCamera = null;

	public float interactionRange = 1.5f;
	#endregion

	#region Properties
	protected bool _canInteract = true;
	#endregion

	void Awake()
	{
		RegisterForEvents();
	}

	void OnDestroy()
	{
		UnregisterForEvents();
	}

	void Update ()
	{
		if (_canInteract = true && interactionKey != EInputKey.None && Input.GetButtonDown (interactionKey.ToString ()))
		{
			TryInteract();
		}
	}

	#region Event Management
	internal void RegisterForEvents()
	{
		EventManager.Instance.RegisterForEvent ("EnableInput", EnableInput);
		EventManager.Instance.RegisterForEvent ("DisableInput", DisableInput);
	}
	
	internal void UnregisterForEvents()
	{
		EventManager.Instance.UnregisterForEvent ("EnableInput", EnableInput);
		EventManager.Instance.UnregisterForEvent ("DisableInput", DisableInput);
	}

	internal void DisableInput(EventParameter args = null)
	{
		controller.enabled = false;
		look.enabled = false;
		_canInteract = false;
		motor.enabled = false;
	}

	internal void EnableInput(EventParameter args = null)
	{

		motor.enabled = true;
		look.enabled = true;
		controller.enabled = true;
		_canInteract = true;
	}
	#endregion

	internal void TryInteract()
	{
		int layerMask = LayerMask.NameToLayer ("Interaction");
		RaycastHit hit;
		if (Physics.Raycast (gameCamera.transform.position,
		                transform.forward,
		                out hit,
		                interactionRange,
		                1 << layerMask))
		{
			Interactable interact = hit.collider.GetComponent<Interactable>();

			if(interact != null)
			{
				interact.OnInteraction();
			}
		}
	}
}
