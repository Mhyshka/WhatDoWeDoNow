using UnityEngine;
using System.Collections;



internal class Popup : Panel
{
	#region Inspector Properties
	public UILabel titleLabel = null;
	public UILabel contentLabel = null;

	public EventButton closeButton = null;
	public EventButton cancelButton = null;
	public EventButton validButton = null;

	public UILabel closeLabel = null;
	public UILabel cancelLabel = null;
	public UILabel validLabel = null;
	#endregion

	#region Properties
	#endregion

	#region Popup Setting
	internal void SetValidData(string a_content)
	{
		closeButton.gameObject.SetActive (false);
		cancelButton.gameObject.SetActive (true);
		validButton.gameObject.SetActive (true);

		contentLabel.text = a_content;
	}


	internal void SetValidData(string a_title, string a_text)
	{
		closeButton.gameObject.SetActive (false);
		cancelButton.gameObject.SetActive (true);
		validButton.gameObject.SetActive (true);
		
		titleLabel.text = a_title;
		contentLabel.text = a_text;
	}
	
	internal void SetValidData(string a_title, string a_text, EInputKey a_cancelKey, EInputKey a_validKey)
	{
		closeButton.gameObject.SetActive (false);
		cancelButton.gameObject.SetActive (true);
		validButton.gameObject.SetActive (true);

		titleLabel.text = a_title;
		contentLabel.text = a_text;

		cancelButton.inputKey = a_cancelKey;
		validButton.inputKey = a_validKey;
	}

	internal void SetCloseData(string a_content)
	{
		closeButton.gameObject.SetActive (false);
		cancelButton.gameObject.SetActive (true);
		validButton.gameObject.SetActive (true);
		
		contentLabel.text = a_content;
	}

	internal void SetCloseData(string a_title, string a_text)
	{
		closeButton.gameObject.SetActive (true);
		cancelButton.gameObject.SetActive (false);
		validButton.gameObject.SetActive (false);
		
		titleLabel.text = a_title;
		contentLabel.text = a_text;
	}

	internal void SetCloseData(string a_title, string a_text, EInputKey a_closeKey)
	{
		closeButton.gameObject.SetActive (true);
		cancelButton.gameObject.SetActive (false);
		validButton.gameObject.SetActive (false);

		titleLabel.text = a_title;
		contentLabel.text = a_text;

		closeButton.inputKey = a_closeKey;
	}
	#endregion

	#region Buttons Text
	internal void SetButtonsText(string a_validText, string a_cancelText)
	{
		validLabel.text = a_validText;
		cancelLabel.text = a_cancelText;
	}

	internal void SetButtonText(string a_closeText)
	{
		closeLabel.text = a_closeText;
	}
	#endregion

	internal override void Show ()
	{
		EventManager.Instance.FireEvent("DisableInput");
		base.Show ();
	}

	internal override void Hide ()
	{
		EventManager.Instance.FireEvent("EnableInput");
		base.Hide ();
	}
}
