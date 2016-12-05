using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
	//Sample
	bool sampleCheck;



	public GameObject playerPos;

	[Space]
	public float moveSpeed;
	float moveSpeed_in;

	public int hp;



	// Use this for initialization
	void Start () {
		hp = 3;
		playerPos = GameObject.Find ("Player");
		moveSpeed_in = moveSpeed;
		//moveSpeed_in = Random.Range(3.0f,5.0f);
		StartCoroutine ("followPlayer");
	
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0) {
			dead ();
		}
	}

	IEnumerator followPlayer() {
		while (true) {
			transform.LookAt (playerPos.transform.position + new Vector3(0,1f,0));
			transform.Translate (0, 0, moveSpeed_in * Time.deltaTime);

			yield return new WaitForSeconds (0.006f);
		}
	}



	void OnCollisionEnter(Collision target) {
		if (target.gameObject.CompareTag ("Car")) {
			if (sampleCheck == false) {
			
				sampleCheck = true;
				Invoke ("dead", 1f);
			}
		}

	}

	void dead(){
		gameObject.SetActive (false);
	}


}
