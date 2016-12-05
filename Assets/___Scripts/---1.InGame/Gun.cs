using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	LineRenderer myLine;
	public GameObject lineEndpos;
	[Space]
	public GameObject gun_roteX;
	public float gunMoveSpeed;
	float gunMoveSpeed_in;

	[Space]
	public Transform GunPos;
	public Transform Rmax;
	public Transform Lmax;
	public Transform Dmax;
	public Transform Umax;

	float rotateZ;
	float rotateW;


	[Space]
	//sample
	bool shootCheck;
	public float shootSpeed;
	public GameObject gunModel;

	// Use this for initialization
	void Start () {
		
		StartCoroutine ("shoot");
		myLine = GetComponent<LineRenderer> ();
		gunMoveSpeed_in = gunMoveSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.DrawRay (transform.position, transform.forward*200f, Color.red);
		Debug.Log(GunPos.transform.localPosition);
		lineSet ();
		GunMove ();

	}

	void lineSet() {
		myLine.SetPosition (0, transform.position);
		myLine.SetPosition (1, lineEndpos.transform.position);
	}

	void GunMove() {
		
		if (Input.GetKey (KeyCode.A)) {
			if (GunPos.transform.localPosition.x < Lmax.transform.localPosition.x) {
				GunPos.transform.localPosition = GunPos.transform.localPosition + new Vector3 ((gunMoveSpeed_in * 0.1f) * Time.deltaTime, 0, 0);
				transform.Rotate (0, -gunMoveSpeed_in * Time.deltaTime, 0);
			}

		}

		if (Input.GetKey (KeyCode.D)) {
			if (GunPos.transform.localPosition.x > Rmax.transform.localPosition.x) {
				GunPos.transform.localPosition = GunPos.transform.localPosition + new Vector3 ((-gunMoveSpeed_in * 0.1f) * Time.deltaTime, 0, 0);
				transform.Rotate (0, gunMoveSpeed_in * Time.deltaTime, 0);
			}

		}



		if (Input.GetKey (KeyCode.W)) {
			if (GunPos.transform.localPosition.y < Umax.transform.localPosition.y) {
				GunPos.transform.localPosition = GunPos.transform.localPosition + new Vector3 (0, (gunMoveSpeed_in * 0.1f) * Time.deltaTime, 0);
				gun_roteX.transform.Rotate (-gunMoveSpeed_in * Time.deltaTime, 0, 0);
			}
			
		}

		if (Input.GetKey (KeyCode.S)) {
			if (GunPos.transform.localPosition.y > Dmax.transform.localPosition.y) {
				GunPos.transform.localPosition = GunPos.transform.localPosition + new Vector3 (0, -(gunMoveSpeed_in * 0.1f) * Time.deltaTime, 0);
				gun_roteX.transform.Rotate (gunMoveSpeed_in * Time.deltaTime, 0, 0);
			}
			
		}


		if (Input.GetKey (KeyCode.Z)) {
			if (shootCheck == false) {
				shootCheck = true;
			}

		}



	}

	IEnumerator shoot() {

		while (true) {
			if (shootCheck) {
				//Vector3 
				gunModel.transform.localPosition = new Vector3 (0, -0.03f, -0.1f);
				yield return new WaitForSeconds (shootSpeed);
				gunModel.transform.localPosition = new Vector3 (0, -0.03f, 0);
				shootCheck = false;
			}


			yield return new WaitForSeconds (0.006f);
		}

	}
}
