using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public int Hp_max;
	int Hp_in;

	public GameObject[] hp_image;

	void Start() {
		Hp_in = Hp_max;
	}

	void Update() {
			if (Hp_in <= 0) {
				//Debug.Log ("GAME OVER!");
			}
	}

	public void hit(int damage) {

		Hp_in = Hp_in - damage;
		image_set (Hp_in);

		Debug.Log (Hp_in);
		if (Hp_in <= 0) {
			Debug.Log ("gameover");
		}
	}



	void image_set(int hp) {
		
		imageoff ();

		switch (hp) {
		case 3:
			
			break;
		case 2:
			hp_image [1].SetActive (true);
			break;
		case 1:
			hp_image [0].SetActive (true);
			break;
		case 0:
			hp_image [0].SetActive (true);
			break;
		default:
			hp_image [0].SetActive (true);
			break;
		}

	}

	void imageoff(){
		hp_image [0].SetActive (false);
		hp_image [1].SetActive (false);
		hp_image [2].SetActive (false);
	}
}
