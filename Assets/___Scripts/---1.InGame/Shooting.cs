using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shooting : MonoBehaviour {

	public Text mod_txt;

	public Transform shootpoint;
	//public float 

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			//Debug.DrawRay (Physics.Raycast(this.transform.position, this.transform.forward * 4,Color.red));
		}

		if (Input.GetKey (KeyCode.A)) {
			shootpoint.transform.Translate (0, 0, 0);
		}
			
		if (Input.GetKey (KeyCode.D)) {
			shootpoint.transform.Translate (0, 0, 0);
		}

		if (Input.GetKey (KeyCode.S)) {
			shootpoint.transform.Translate (0, 0, 0);
		}

		if (Input.GetKey (KeyCode.W)) {
			shootpoint.transform.Translate (0, 0, 0);
		}
	}
}
