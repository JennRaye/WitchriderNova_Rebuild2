using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WitchScriptNet : NetworkBehaviour {
	public CharacterController thisController;
	public NetworkBehaviour thisNetworkBehaviour;
	public WitchScript thisWitchScript;
	[SyncVar]
	public Vector3 moveDirectionNetSave;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (thisNetworkBehaviour.isLocalPlayer == true) {
		//	moveDirectionNetSave = thisWitchScript.moveDirection;
		} else {
		//	thisWitchScript.moveDirection = moveDirectionNetSave;

		}
	}
}
