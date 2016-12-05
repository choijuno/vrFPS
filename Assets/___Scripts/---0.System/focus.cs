using UnityEngine;
using System.Collections;

public class focus : MonoBehaviour {
	public Camera eye;

	float i;

	void Start () {
		setfocus ();
	}

	void setfocus() {
		//eye.transform.localRotation = ;
		StartCoroutine("startfocus");
	}

	IEnumerator startfocus() {
		while (true) {
			transform.Rotate (0, Input.GetAxis ("Mouse X"), 0, 0);
			/*
			if (GameManager.unityMod) {
				transform.LookAt (worldPosition:Input.mousePosition);
			} else {
				transform.Rotate (0, Input.GetAxis ("Mouse X"), 0, 0);
			}
			*/
		yield return new WaitForSeconds(0.006f);

		}
	}
}