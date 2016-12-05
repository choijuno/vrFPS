using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BtnController : MonoBehaviour {

	public Text mod_txt;

	public void mod_change() {
		if (mod_txt.text == "MOD : PC") {
			mod_txt.text = "MOD : UNITY";
			GameManager.unityMod = true;
		} else {
			mod_txt.text = "MOD : PC";
			GameManager.unityMod = false;
		}
	
	}
}
