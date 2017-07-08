using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacePlayer : MonoBehaviour {
	public Transform CameraTrans;
	public Transform Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CameraTrans.LookAt (Player);
	}
}
