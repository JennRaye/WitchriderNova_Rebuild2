using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterviewer : MonoBehaviour {

    public GameObject Child;
	public characterselect characterselect;
	public float characterindex;
	public MeshRenderer MeshRenderer;


	// Use this for initialization
	void Start () {
		MeshRenderer = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		characterselect = GetComponentInParent<characterselect> ();

		if (characterselect.currentcharacter == characterindex) {
			MeshRenderer.enabled = true;
			Child.SetActive (true);
		}

		if (characterselect.currentcharacter != characterindex) {
			MeshRenderer.enabled = false; 
			Child.SetActive (false);
		}

	}
}
