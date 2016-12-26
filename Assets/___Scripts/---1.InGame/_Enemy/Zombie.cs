using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
	//Sample
	bool sampleCheck;
	bool dieCheck;



	[Space]

	public AudioSource dead_sound;

	[Space]



	public Animator myAni;

	public GameObject playerPos;

	[Space]
	public float moveSpeed;
	float moveSpeed_in;

	public int hp;

	[Space]
	public GameObject att_C;
	bool att_Check;

	[Space]
	public lookPos mylook;




	public enum lookPos {
		BASE = 0,
		LL_1,
		LR_2,
		RL_3,
		RR_4,
	}



	// Use this for initialization
	void Start () {
		myAni = myAni.GetComponent<Animator> ();
		hp = 3;


		switch(mylook){
		case lookPos.BASE:
			playerPos = GameObject.Find ("Player");
			break;
		case lookPos.LL_1:
			playerPos = GameObject.Find ("posLL");
			break;
		case lookPos.LR_2:
			playerPos = GameObject.Find ("posLR");
			break;
		case lookPos.RL_3:
			playerPos = GameObject.Find ("posRL");
			break;
		case lookPos.RR_4:
			playerPos = GameObject.Find ("posRR");
			break;


		}


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

			if (!att_Check) {
				att_Check = true;
				myAni.SetBool ("Attack", true);
				Invoke ("att", 0.1f);
			} else {
				return;
			}

			/*
			if (sampleCheck == false) {
			
				sampleCheck = true;
				//Invoke ("dead", 1f);
			}*/


		}

	}

	void att() {
		myAni.SetBool ("Attack", false);
		att_C.SetActive (true);
		Invoke ("att_end", 0.15f);
	}

	void att_end() {
		att_Check = false;
		att_C.SetActive (false);
	}

	void dead(){
		//gameObject.SetActive (false);
		myAni.SetBool("Die", true);
		dead_sound.Play ();
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
