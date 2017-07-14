using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgrotate : MonoBehaviour {

	public Transform transform;
	public float rotationspeed;
		
	// Use this for initialization
	void Start () {
		transform = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * rotationspeed * Time.deltaTime);
	}
}
