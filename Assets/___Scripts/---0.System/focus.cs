using UnityEngine;
using System.Collections;

public class focus : MonoBehaviour {
	public Transform basePos;
	Vector3 basePosXY;
	float Rx;
	float Ry;
	public Transform myCamera;

	public bool ViveCheck;


	void Start () {
		
		basePosXY = basePos.transform.position;

		StartCoroutine ("startfocus");
	}



	IEnumerator startfocus() {
		while (true) {

			myCamera.transform.localPosition = new Vector3 (Mathf.Lerp(myCamera.transform.localPosition.x,basePos.transform.localPosition.x,0.1f),Mathf.Lerp(myCamera.transform.localPosition.y,basePos.transform.localPosition.y,0.1f),0);


		yield return new WaitForSeconds(0.006f);

		}
	}


	void Update() {
		if (ViveCheck) {

		}
	}


	public void vive() {
		ViveCheck = true;
	}
}