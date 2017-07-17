using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class CustomNetworkTrans : NetworkBehaviour {


	[SyncVar] 
	public Vector3 realPosition = Vector3.zero;
	[SyncVar]
	public Quaternion realRotation;
	[SyncVar]
	public Vector3 realVelocity;
	private float updateTick;
	public float updateInterval;
	public CharacterController thisController;
	public Transform thisTransform;
	public float LerpFactor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isLocalPlayer == true){
			updateTick += Time.deltaTime;
			if (updateTick > updateInterval) {
				CmdSync (thisTransform.position, thisTransform.rotation, thisController.velocity);
			}
		}
		else {
			transform.position = Vector3.Lerp (thisTransform.position, realPosition, LerpFactor);
			transform.rotation = Quaternion.Lerp (thisTransform.rotation, realRotation, LerpFactor);

		}
	}

	[Command]
	void CmdSync(Vector3 position, Quaternion rotation, Vector3 velocity){
		realPosition = position;
		realRotation = rotation;
		realVelocity = velocity;
	}
}
