using UnityEngine;
using System.Collections;

public class zombieSample : MonoBehaviour {
	float random;
	// Use this for initialization
	void Start () {
		StartCoroutine ("imageC");
		random = Random.Range (0.15f, 0.3f);
	}
	
	IEnumerator imageC(){
		while (true) {
			yield return new WaitForSeconds (random);
			if (transform.localScale.x == 1) {
				transform.localScale = new Vector3 (-1,1,1);
			} else {
				transform.localScale = new Vector3 (1,1,1);
			}
		}
	}
}
