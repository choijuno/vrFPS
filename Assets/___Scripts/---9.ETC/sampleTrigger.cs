using UnityEngine;
using System.Collections;

public class sampleTrigger : MonoBehaviour {
	public GameObject sponPoint;
	bool sponCheck;

	void OnTriggerEnter(Collider target) {

		if (target.gameObject.CompareTag ("Car")) {
			if (sponCheck == false) {
				sponCheck = true;
				sponPoint.SetActive (true);
				this.gameObject.SetActive (false);
			}
		}

	}
}
