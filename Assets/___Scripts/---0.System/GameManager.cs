using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {


	void Start () {
		switch (Application.loadedLevelName) {
		case "00_Start":
			StartCoroutine ("mainUpdate");
			break;

		}
	}
	

	void Update () {
		
	}

	IEnumerator mainUpdate(){

		while (true) {

			if (Input.anyKeyDown) {
				Application.LoadLevel ("01_Stage1");
			}





			yield return null;



		}
	}
}
