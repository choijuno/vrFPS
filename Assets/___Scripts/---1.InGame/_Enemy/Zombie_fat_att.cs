using UnityEngine;
using System.Collections;

public class Zombie_fat_att : MonoBehaviour {



	void OnEnable() {
		
	}


	void OnTriggerEnter(Collider Target) {
		
		if (Target.gameObject.CompareTag ("Car")) {
			Debug.Log (Target.gameObject);
			Target.GetComponent<CarCol> ().Car_Parent.GetComponent<Car> ().SendMessage("hit",1);
			this.gameObject.SetActive (false);
		}

	}

}
