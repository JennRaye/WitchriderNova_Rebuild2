using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchScript : MonoBehaviour {
	public float speed;
	public float Acceleration;
	public float SlowdownAcceleration;
	public float topSpeed;



	public float rotSpeed;
	public float rotAcceleration;
	public float rotSlowdownAcceleration;
	public float rotTopSpeed;

	public float jumpSpeed;
	public float gravity;
	private Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;
	public Transform thisTrans;

	public int Momentum;
	public Vector3 MomentumMoveDirectionSave;


	public Vector3 VelocitySave;

	public Transform CameraTrans;
	public Transform CameraTarget;

	public float CameraSpeed;
	public float CameraRotSpeed;
	void Start() {
		controller = GetComponent<CharacterController>();
	}

	void FixedUpdate() {
		moveDirection = new Vector3 (0, 0, 0);
		if (controller.isGrounded) {
			

		}



		if (Input.GetAxis ("Horizontal") == 0) {
			if (Input.GetButton ("Accelerate")) {
				if (speed < topSpeed)
					speed += Acceleration * Time.deltaTime;
				else
					speed = topSpeed;
			} else {
				if (speed > 0)
					speed -= SlowdownAcceleration * Time.deltaTime;
				else
					speed = 0;
			}
		} else {
			if (speed > 0)
				speed -= SlowdownAcceleration * Time.deltaTime;
			else
				speed = 0;
		}


		moveDirection = new Vector3(moveDirection.x, moveDirection.y, speed * Time.deltaTime);



		moveDirection = transform.TransformDirection (moveDirection);

//		if (Input.GetAxis ("Horizontal") != 0){
//			if (Momentum == 0) {
//				MomentumMoveDirectionSave = moveDirection;
//				Momentum = 1;
//			}
//		}
//
//
//		if (Momentum == 1) {
//
//			moveDirection = new Vector3(moveDirection.x + MomentumMoveDirectionSave.x, moveDirection.y + MomentumMoveDirectionSave.y, speed * Time.deltaTime);
//			if (Input.GetAxis ("Horizontal") == 0)
//				Momentum = 0;
//		}


		if (Input.GetAxis ("Horizontal") != 0){
			if (Momentum == 0) {
				VelocitySave = controller.velocity;
				Momentum = 1;
			}
		}

		if (Momentum == 1) {
			VelocitySave = new Vector3 (Mathf.Lerp (VelocitySave.x, 0, Time.deltaTime * 0.4f), VelocitySave.y, Mathf.Lerp (VelocitySave.z, 0, Time.deltaTime * 0.4f));
			moveDirection = new Vector3(VelocitySave.x, moveDirection.y, VelocitySave.z);
			if (Input.GetAxis ("Horizontal") == 0)
				Momentum = 0;
		}




		// Debug.Log (controller.velocity);





		thisTrans.Rotate (0, Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime, 0);




		// CameraTrans.eulerAngles = new Vector3 (Mathf.Lerp(CameraTrans.eulerAngles.x, thisTrans.eulerAngles.x, Time.deltaTime*5), CameraTrans.eulerAngles.y, Mathf.Lerp(CameraTrans.eulerAngles.z, Input.GetAxis ("Horizontal")*5f, Time.deltaTime*4));
		CameraTrans.rotation = new Quaternion( Mathf.Lerp(CameraTrans.rotation.x, CameraTarget.rotation.x, Time.deltaTime*CameraRotSpeed), Mathf.Lerp(CameraTrans.rotation.y, CameraTarget.rotation.y, Time.deltaTime*CameraRotSpeed), Mathf.Lerp(CameraTrans.rotation.z, CameraTarget.rotation.z, Time.deltaTime*CameraRotSpeed), Mathf.Lerp(CameraTrans.rotation.w, CameraTarget.rotation.w, Time.deltaTime*CameraRotSpeed) );

		CameraTrans.position = new Vector3( Mathf.Lerp(CameraTrans.position.x, CameraTarget.position.x, Time.deltaTime*CameraSpeed), Mathf.Lerp(CameraTrans.position.y, CameraTarget.position.y, Time.deltaTime*CameraSpeed), Mathf.Lerp(CameraTrans.position.z, CameraTarget.position.z, Time.deltaTime*CameraSpeed) );

		if (Input.GetButton("Fly"))
			moveDirection.y = jumpSpeed * Time.deltaTime;



		moveDirection.y -= gravity * Time.deltaTime;


		controller.Move(moveDirection * Time.deltaTime);

	}

}
