using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
	//Sample
	bool sampleCheck;
	bool dieCheck;



	public Animator myAni;

	public GameObject playerPos;

	[Space]
	public float moveSpeed;
	float moveSpeed_in;

	public int hp;



	// Use this for initialization
	void Start () {
		myAni = myAni.GetComponent<Animator> ();
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
			if (!dieCheck) {
				transform.LookAt (playerPos.transform.position + new Vector3 (0, 1f, 0));
				transform.Translate (0, 0, moveSpeed_in * Time.deltaTime);
			}
			yield return new WaitForSeconds (0.006f);
		}
	}



	void OnCollisionEnter(Collision target) {
		if (target.gameObject.CompareTag ("Car")) {

			myAni.SetBool("Attack",true);


			/*
			if (sampleCheck == false) {
			
				sampleCheck = true;
				//Invoke ("dead", 1f);
			}*/


		}

	}


	void dead(){
		//gameObject.SetActive (false);
		myAni.SetBool("Die", true);
		this.enabled = false;
		dieCheck = true;
		//StartCoroutine ("followPlayer");

	}

	public void hitCheck(int damage) {
		hp -= damage;

		if (hp <= 0) {
			dead ();
		}
	}

}
