using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BeamScriptNet : NetworkBehaviour {
	
	[SyncVar]
	public Vector2 realPosition = Vector3.zero;
	[SyncVar]
	public Vector2 realDirection = Vector3.zero;


	public BeamScript thisBeamScript;
	public Transform thisTransform;
	public float updateTick;
	public float updateInterval;

	[SyncVar]
	private bool OneTimeUpdate;
	// public float LerpFactor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isServer == true){
			updateTick += Time.deltaTime;
			if (updateTick > updateInterval) {
				CmdSync (thisTransform.position);
			}
		}
		else {
			if (OneTimeUpdate == true) {
				thisTransform.position = new Vector3 (realPosition.x, thisTransform.position.y, realPosition.y);
				thisBeamScript.DirectionMove = realDirection;
				OneTimeUpdate = false;
				Debug.Log ("Success1");
			} else {
				Debug.Log ("Success2");
			}
//				thisTransform.position = Vector3.Lerp (thisTransform.position, new Vector3(realPosition.x, thisTransform.position.y, realPosition.y), transform, LerpFactor);


		}

		if (thisBeamScript.UpdateOnline == true) {
			CmdSync (thisTransform.position);
			thisBeamScript.UpdateOnline = false;

		}
	}

	[Command]
	void CmdSync(Vector3 position){
			realPosition = new Vector2 (thisTransform.position.x, thisTransform.position.z);
			realDirection = thisBeamScript.DirectionMove;
		OneTimeUpdate = true;
	}
}
