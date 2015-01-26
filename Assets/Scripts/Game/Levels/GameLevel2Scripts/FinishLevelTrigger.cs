using UnityEngine;
using System.Collections;

public class FinishLevelTrigger : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		EventManager.Instance.FireEvent ("LevelComplete");
	}
}
