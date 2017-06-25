using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchScript : MonoBehaviour {
	public float speed;
	public float rotSpeed;
	public float jumpSpeed;
	public float gravity;
	private Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;
	public Transform thisTrans;


	void Start() {
		controller = GetComponent<CharacterController>();
	}

	void FixedUpdate() {
		moveDirection = new Vector3 (0, 0, 0);
		if (controller.isGrounded) {
			

		}






		// moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if (Input.GetButton("Accelerate")) moveDirection = new Vector3(moveDirection.x, moveDirection.y, speed * Time.deltaTime);


		moveDirection = transform.TransformDirection (moveDirection);

		thisTrans.Rotate (0, Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime, 0);


		if (Input.GetButton("Fly"))
			moveDirection.y = jumpSpeed * Time.deltaTime;



		moveDirection.y -= gravity * Time.deltaTime;


		controller.Move(moveDirection * Time.deltaTime);
		
	}

}
