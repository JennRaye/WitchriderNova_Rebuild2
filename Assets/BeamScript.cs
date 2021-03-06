﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BeamScript : MonoBehaviour {
	public Vector2 MinAxis;
	public Vector2 MaxAxis;
	public Vector2 DirectionMove;
	public float DirectionSpeed;
	public Transform thisTrans;

	public float ChangeTimer;
	public bool UpdateOnline;
	// Use this for initialization
	void Start () {
		
	}

	void Update(){
		thisTrans.position = new Vector3 (thisTrans.position.x + (DirectionMove.x*DirectionSpeed*Time.deltaTime), 0, thisTrans.position.z + (DirectionMove.y*DirectionSpeed*Time.deltaTime));
		if (thisTrans.position.x < MinAxis.x) DirectionMove = new Vector2 (1f, DirectionMove.y);
		if (thisTrans.position.x > MaxAxis.x) DirectionMove = new Vector2 (-1f, DirectionMove.y);
		if (thisTrans.position.z < MinAxis.y) DirectionMove = new Vector2 (DirectionMove.x, 1f);
		if (thisTrans.position.z > MaxAxis.y) DirectionMove = new Vector2 (DirectionMove.x, -1f);

		//ChangeTimer += Time.deltaTime;
		//if (ChangeTimer >= 4) {
		//	ResetDirection ();
		//}

		if (DirectionMove.x == 0 && DirectionMove.y == 0) {
			ResetDirection ();
		}
	}
	void ResetDirection(){
		DirectionMove = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
		ChangeTimer = 0;
	}
	void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "WitchPlayer") {
			if (hit.gameObject.GetComponent<WitchScriptNet> ().isLocalPlayer == true) {
				thisTrans.position = new Vector3 (Random.Range (MinAxis.x, MaxAxis.x), 0, Random.Range (MinAxis.y, MaxAxis.y));
				ResetDirection ();
				UpdateOnline = true;
			}

		}
	}
}
