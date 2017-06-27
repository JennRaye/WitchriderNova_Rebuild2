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




	public float flySpeed;
	public float gravity;
	public float flySpeed2;
	public float flyTopSpeed;


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


	public Animator thisAnim;

	public float SpeedBoost;
	public float BoostTopSpeed;
	public float BoostActualTopSpeed;
	public float BoostCoolOffSpeed;

	public float TurnFl;
	public float AccelFl;

	// public Quaternion thisRot;
	void Start() {
		controller = GetComponent<CharacterController>();
	}

	void FixedUpdate() {
		moveDirection = new Vector3 (0, 0, 0);
		if (controller.isGrounded) {
			

		}


		// if (Input.GetAxis ("Horizontal") == 0) {
		if (Input.GetAxis ("Brake") == 0) {
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



//		else if (Input.GetAxis ("Accelerate") < 0) {
//			if (speed > 0)
//				speed -= SlowdownAcceleration*2f * Time.deltaTime;
//			else
//				speed = 0;
//		}
	

//		} else {
//			if (speed > 0)
//				speed -= SlowdownAcceleration * Time.deltaTime;
//			else
//				speed = 0;
//		}

		if (SpeedBoost > 0)
			SpeedBoost -= Time.deltaTime * BoostCoolOffSpeed;
		else
			SpeedBoost = 0;



		if (SpeedBoost > BoostTopSpeed) {

			moveDirection = new Vector3(moveDirection.x, moveDirection.y, (speed + BoostTopSpeed) * Time.deltaTime);
		}
		else 
			moveDirection = new Vector3(moveDirection.x, moveDirection.y, (speed + SpeedBoost) * Time.deltaTime);




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







//		if (Input.GetAxis ("Horizontal") != 0){
//			if (Momentum == 0) {
//				VelocitySave = controller.velocity;
//				Momentum = 1;
//			}
//		}
//
//		if (Momentum == 1) {
//			VelocitySave = new Vector3 (Mathf.Lerp (VelocitySave.x, 0, Time.deltaTime * 0.4f), VelocitySave.y, Mathf.Lerp (VelocitySave.z, 0, Time.deltaTime * 0.4f));
//			moveDirection = new Vector3(VelocitySave.x, moveDirection.y, VelocitySave.z);
//			if (Input.GetAxis ("Horizontal") == 0)
//				Momentum = 0;
//		}







		// Debug.Log (controller.velocity);





		thisTrans.Rotate (0, Input.GetAxis ("Horizontal") * (rotSpeed - (speed / topSpeed)*150) * Time.deltaTime, 0);
		//if (Input.GetAxis ("Accelerate") < 0)
		if ((speed / topSpeed) < 0.5f) {
		//	thisTrans.Rotate (0, Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime*0.25f, 0);
		}



		TurnFl = Mathf.Lerp (TurnFl, Input.GetAxis ("Horizontal"), Time.deltaTime * 3);
			
		AccelFl = speed / topSpeed;

		thisAnim.SetFloat ("Turn", TurnFl);
		thisAnim.SetFloat ("Accel", AccelFl);





		if (Input.GetButtonDown ("Fly")) {
			if (flySpeed < 0)
				flySpeed = 0;
		}


		if (Input.GetButton ("Fly")) {
			if (flySpeed < flyTopSpeed) {
				flySpeed += Time.deltaTime * flySpeed2;
			} else
				flySpeed = flyTopSpeed;
		} else {
			if (flySpeed > gravity) {
				flySpeed -= Time.deltaTime * flySpeed2;
			} else
				flySpeed = gravity;
		}
		//	moveDirection.y = jumpSpeed * Time.deltaTime;

		moveDirection.y = flySpeed;


		// moveDirection.y -= gravity * Time.deltaTime;


		controller.Move(moveDirection * Time.deltaTime);


		// CameraTrans.eulerAngles = new Vector3 (Mathf.Lerp(CameraTrans.eulerAngles.x, thisTrans.eulerAngles.x, Time.deltaTime*5), CameraTrans.eulerAngles.y, Mathf.Lerp(CameraTrans.eulerAngles.z, Input.GetAxis ("Horizontal")*5f, Time.deltaTime*4));
		CameraTrans.rotation = new Quaternion( Mathf.Lerp(CameraTrans.rotation.x, CameraTarget.rotation.x, Time.deltaTime*CameraRotSpeed), Mathf.Lerp(CameraTrans.rotation.y, CameraTarget.rotation.y, Time.deltaTime*CameraRotSpeed), Mathf.Lerp(CameraTrans.rotation.z, CameraTarget.rotation.z, Time.deltaTime*CameraRotSpeed), Mathf.Lerp(CameraTrans.rotation.w, CameraTarget.rotation.w, Time.deltaTime*CameraRotSpeed) );
		// Mathf.Lerp(CameraTrans.position.y, CameraTarget.position.y, Time.deltaTime*(CameraSpeed/2f))
		CameraTrans.position = new Vector3( Mathf.Lerp(CameraTrans.position.x, CameraTarget.position.x, Time.deltaTime*CameraSpeed), Mathf.Lerp(CameraTrans.position.y, CameraTarget.position.y, Time.deltaTime*(CameraSpeed*2f)), Mathf.Lerp(CameraTrans.position.z, CameraTarget.position.z, Time.deltaTime*CameraSpeed) );




	}


	void OnControllerColliderEnter(ControllerColliderHit hit){
		if (hit.gameObject.tag == "BoostRing"){
			SpeedBoost = BoostActualTopSpeed;
			Debug.Log ("hit!");
		}
	}

}
