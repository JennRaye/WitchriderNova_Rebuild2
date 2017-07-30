using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterviewer : MonoBehaviour {

    public GameObject Child;
	public characterselect characterselect;
	public float characterindex;
//	public MeshRenderer MeshRenderer;
//	public float startpos;
//	private float endpos;
//	public float transitionspeed;
//	public bool enterb;
	public Transform transform;
	public float startTime;
	public Image image;
	public GameObject Icon;
	public Vector3 highlightscalesize;
	public Vector3 defaultsize;
	private RectTransform tempicon;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		transform = GetComponent<Transform> ();
//		endpos = transform.position.x; 
		image = GetComponent<UnityEngine.UI.Image> ();
		tempicon = Icon.GetComponent<RectTransform> ();
//		MeshRenderer = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		characterselect = GetComponentInParent<characterselect> ();

		if (characterselect.currentcharacter == characterindex) {
//			MeshRenderer.enabled = true;
			Child.SetActive (true);
			image.enabled = true;
			tempicon.SetAsLastSibling ();
			tempicon.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 75.0f);
			tempicon.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 75.0f);
		
		}

		if (characterselect.currentcharacter != characterindex) {
//			MeshRenderer.enabled = false; 
			Child.SetActive (false);
			image.enabled = false;
	//		tempicon.localScale.Set (0.6f, 0.6f, 0.6f);
			tempicon.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 60.0f);
			tempicon.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 60.0f);
		}

	}

	void Enter () {
		}

}
