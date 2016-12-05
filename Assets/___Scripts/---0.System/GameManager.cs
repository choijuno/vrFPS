using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static bool unityMod;
	public GameObject cam;
	public Text mod_txt;

	void Start () {
		modReset ();

	}

	void modReset() {
		if (unityMod) {
			mod_txt.text = "MOD : UNITY";
		} else {
			mod_txt.text = "MOD : PC";
		}
	}
	

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			
			if (GameManager.unityMod) {
				mod_txt.text = "MOD : UNITY";
				cam.GetComponent<focus> ().enabled = false;
				cam.GetComponent<SmoothMouseLook> ().enabled = true;
				GameManager.unityMod = false;
			} else {
				mod_txt.text = "MOD : PC";
				GameManager.unityMod = true;
				cam.GetComponent<focus> ().enabled = true;
				cam.GetComponent<SmoothMouseLook> ().enabled = false;
			}
			cam.transform.rotation = new Quaternion (0, 0, 0, 0);
		}
	}
}
