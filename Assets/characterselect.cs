using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterselect : MonoBehaviour {

	public float currentcharacter;
	public float charactertotal;
	private bool pressed;
	public bool fadein;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Horizontal") == 0 && pressed == true){
			pressed = false;
		}

		if (Input.GetAxis ("Horizontal") > 0 && pressed == false) {
			pressed = true;
			currentcharacter += 1;
			if (fadein == false) {
				fadein = true;
			}
		}
	
		if (Input.GetAxis ("Horizontal") < 0 && pressed == false) {
			pressed = true;
			currentcharacter -= 1;
			if (fadein == false) {
				fadein = true;
			}
		}
		currentcharacter = (currentcharacter % charactertotal + charactertotal)%charactertotal;
	}
}
