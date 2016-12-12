using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Gun : MonoBehaviour {
	public GameObject lineEndpos;
	public TextMesh bullet_txt;

	[Space] //FPS_Fire
	public ImpactInfo[] ImpactElemets = new ImpactInfo[0];
	public float BulletDistance = 100;
	public GameObject ImpactEffect;
	public GameObject lazerPos;



	[Space]
	public GameObject gun_roteX;
	public float gunMoveSpeed;
	float gunMoveSpeed_in;
	public int gunBulletMax;
	int gunBullet;
	public float reloadSpeed;

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
		gunBullet = gunBulletMax;
		StartCoroutine ("shoot");
		gunMoveSpeed_in = gunMoveSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.DrawRay (transform.position, transform.forward*200f, Color.red);
		//Debug.Log(GunPos.transform.localPosition);

		GunMove ();
		bulletCheck ();

	}



	void bulletCheck() {
		
	}

	void GunMove() {

		//right
		if (Input.GetAxis ("Horizontal") > 0) {
			
			if (GunPos.transform.localPosition.x > Rmax.transform.localPosition.x) {
				GunPos.transform.localPosition = GunPos.transform.localPosition + new Vector3 (((gunMoveSpeed_in * 0.1f) * -Input.GetAxis ("Horizontal")) * Time.deltaTime, 0, 0);
				transform.Rotate (0, (gunMoveSpeed_in * Input.GetAxis ("Horizontal")) * Time.deltaTime, 0);
			}
		}
		//left
		if (Input.GetAxis ("Horizontal") < 0) {
			if (GunPos.transform.localPosition.x < Lmax.transform.localPosition.x) {
				GunPos.transform.localPosition = GunPos.transform.localPosition + new Vector3 (((gunMoveSpeed_in * 0.1f) * -Input.GetAxis ("Horizontal")) * Time.deltaTime, 0, 0);
				transform.Rotate (0, (gunMoveSpeed_in * Input.GetAxis ("Horizontal")) * Time.deltaTime, 0);
			}

		}
		//up
		if (Input.GetAxis ("Vertical") > 0) {
			if (GunPos.transform.localPosition.y < Umax.transform.localPosition.y) {
				GunPos.transform.localPosition = GunPos.transform.localPosition + new Vector3 (0, ((gunMoveSpeed_in * 0.1f) * Input.GetAxis ("Vertical")) * Time.deltaTime, 0);
				gun_roteX.transform.Rotate ((gunMoveSpeed_in * -Input.GetAxis ("Vertical")) * Time.deltaTime, 0, 0);
			}

		}
		//down
		if (Input.GetAxis ("Vertical") < 0) {
			if (GunPos.transform.localPosition.y > Dmax.transform.localPosition.y) {
				GunPos.transform.localPosition = GunPos.transform.localPosition + new Vector3 (0, ((gunMoveSpeed_in * 0.1f) * Input.GetAxis ("Vertical")) * Time.deltaTime, 0);
				gun_roteX.transform.Rotate ((gunMoveSpeed_in * -Input.GetAxis ("Vertical")) * Time.deltaTime, 0, 0);
			}
		}





		/*
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
		*/
		if (Input.GetButton ("Reload")) {
			if (shootCheck == false) {
				if (gunBullet < gunBulletMax) {
					gunBullet = 0;
					shootCheck = true;
				}
			
			}
		}


		if (Input.GetButton ("Shoot")) {
			
			if (shootCheck == false) {
				bullet_txt.text = "Bullet " + gunBullet	+ " / " + gunBulletMax;
				shootCheck = true;
				
			}



		} else {
			GamePad.SetVibration (0, 0f, 0f);
		}



	}

	IEnumerator shoot() {
		
		RaycastHit Hit;

		while (true) {
			if (shootCheck) {

				if (gunBullet > 0) {
					//Vector3 
					gunModel.transform.localPosition = new Vector3 (0, gunModel.transform.localPosition.y, -0.01f);
					GamePad.SetVibration (0, 1f, 1f);
					if (Physics.Raycast (lazerPos.transform.position, lazerPos.transform.forward, out Hit, 4000f)) {
						if (Hit.collider.gameObject.CompareTag ("body")) {
							Hit.transform.gameObject.GetComponent<Zombie> ().hitCheck (1);
							Debug.Log ("body");
						}
						if (Hit.collider.gameObject.CompareTag ("head")) {
							Hit.transform.gameObject.GetComponent<Zombie> ().hitCheck (2);
							Debug.Log ("head");
						}

						var effect = GetImpactEffect (Hit.transform.gameObject);
						if (effect == null)
							yield return null;
						var effectIstance = Instantiate (effect, Hit.point, new Quaternion ()) as GameObject;
						effectIstance.transform.LookAt (Hit.point + Hit.normal);
						Destroy (effectIstance, 4);

					}






					ImpactEffect.SetActive(false);
					ImpactEffect.SetActive(true);
					gunBullet -= 1;

					GamePad.SetVibration (0, 1f, 1f);



					yield return new WaitForSeconds (shootSpeed);
					gunModel.transform.localPosition = new Vector3 (0, gunModel.transform.localPosition.y, 0);

					shootCheck = false;



				} else {

					GamePad.SetVibration (0, 0f, 0f);

					bullet_txt.text = "reload...";
					yield return new WaitForSeconds (reloadSpeed);
					shootCheck = false;
					reload ();


				}

			}


			yield return new WaitForSeconds (0.006f);
		}

	}

	void reload() {
		if (gunBullet <= 0) {
			gunBullet = gunBulletMax;
		}
		bullet_txt.text = "Bullet " + gunBullet	+ " / " + gunBulletMax;
	}



	[System.Serializable]
	public class ImpactInfo
	{
		public MaterialType.MaterialTypeEnum MaterialType;
		public GameObject ImpactEffect;
	}

	GameObject GetImpactEffect(GameObject impactedGameObject)
	{
		var materialType = impactedGameObject.GetComponent<MaterialType>();
		if (materialType==null)
			return null;
		foreach (var impactInfo in ImpactElemets)
		{
			if (impactInfo.MaterialType==materialType.TypeOfMaterial)
				return impactInfo.ImpactEffect;
		}
		return null;
	}
}
