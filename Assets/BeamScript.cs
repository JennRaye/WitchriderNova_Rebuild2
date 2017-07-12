using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour {
	public Vector2 MinAxis;
	public Vector2 MaxAxis;
	public Transform thisTrans;
	// Use this for initialization
	void Start () {
		
	}



	void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "WitchPlayer") {
			thisTrans.position = new Vector3 (Random.Range (MinAxis.x, MaxAxis.x), 0, Random.Range (MinAxis.y, MaxAxis.y));
		}
	}
}
