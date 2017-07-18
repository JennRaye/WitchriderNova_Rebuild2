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
	[SyncVar]
	public int SyncUpSegments;
	private float updateTick;
	public float updateInterval;
	public CharacterController thisController;
	public Transform thisTransform;
	public float LerpFactor;
	public WitchScript thisWitchScript;
	public GameObject[] SpawnPoints;
	// public WitchScript thisw

	// Use this for initialization
	void Start () {
		if (isLocalPlayer == true){
			SpawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
			// Debug.Log ("... success?");
			thisTransform.position = SpawnPoints[Random.Range(0, SpawnPoints.Length)].transform.position;
			thisTransform.rotation = SpawnPoints[Random.Range(0, SpawnPoints.Length)].transform.rotation;
		}
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
			switch(SyncUpSegments){
			case 0:
				thisTransform.position = Vector3.Lerp (thisTransform.position, realPosition, LerpFactor);
				// thisTransform.position = new Vector3 (Mathf.Lerp (thisTransform.position.x, realPosition.x, LerpFactor * realVelocity.x), Mathf.Lerp (thisTransform.position.y, realPosition.y, LerpFactor * realVelocity.y), Mathf.Lerp (thisTransform.position.z, realPosition.z, LerpFactor * realVelocity.z));

				thisTransform.rotation = Quaternion.Lerp (thisTransform.rotation, realRotation, 0.2f);
				if (Vector3.Distance (thisTransform.position, realPosition) <= 0.5f) {
					SyncUpSegments = 1;
				}
				break;
			case 1:
				thisTransform.rotation = Quaternion.Lerp (thisTransform.rotation, realRotation, 0.2f);


				if (Vector3.Distance (realVelocity, Vector3.zero) <= 1.25f) {
					thisTransform.position = Vector3.Lerp (thisTransform.position, realPosition, LerpFactor);
				} else {
					thisController.Move (realVelocity * Time.deltaTime);
				}

				break;
			}


		}
	}

	[Command]
	void CmdSync(Vector3 position, Quaternion rotation, Vector3 velocity){
		realPosition = position;
		realRotation = rotation;
		realVelocity = thisController.velocity;
		SyncUpSegments = 0;
	}
}
