using UnityEngine;
using System.Collections;

public class shootSound : MonoBehaviour {
	public AudioSource Shoot_sound;

	
	void OnEnable() {
		Shoot_sound.Play ();
	}

}