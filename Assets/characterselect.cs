using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterselect : MonoBehaviour {

	public float currentcharacter;
	public float charactertotal;
	private bool pressed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		currentcharacter = Mathf.Abs(currentcharacter % charactertotal);

		if (Input.GetAxis ("Horizontal") == 0 && pressed == true){
			pressed = false;
		}

		if (Input.GetAxis ("Horizontal") > 0 && pressed == false) {
			pressed = true;
			currentcharacter += 1;
		}
	
		if (Input.GetAxis ("Horizontal") < 0 && pressed == false) {
			pressed = true;
			currentcharacter -= 1;
		}
	}
}
