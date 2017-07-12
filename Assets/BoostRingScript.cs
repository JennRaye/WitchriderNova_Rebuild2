using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostRingScript : MonoBehaviour {

	
	void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "WitchPlayer") {
			hit.GetComponent<WitchScript> ().HitBoostRing ();
		}
	}
}
