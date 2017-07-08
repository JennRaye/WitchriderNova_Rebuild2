using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchScript : MonoBehaviour {

	public enum WitchCharacters {Runi, Loda, Faye, SugarSpice, Ricky, Atlas, Gretchen, Jewel };
	public WitchCharacters WitchChar;
	public GameObject[] WitchModels;


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
	public GameObject CameraObjToInstantiate;
	public GameObject CameraObj;
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


	public Transform CameraTargetGround;
	public Transform CameraTargetFlying;

	public float CameraYTilt;
	public float CameraYRaise;
	public float TurnSpeedDec;
	public Transform WitchModel;
	public GameObject WitchModelObject;
	public float WitchTiltAngle;
	public float WitchTiltAngleMax;
	public float WitchTiltAngleSpeed;
	public float BobbingHeight;
	public float BobbingSpeed;
	public int BobbingMode;

	public GameObject FrontCamera;
	public bool FrontCamShow;



	// public Quaternion thisRot;
	void Start() {
		controller = GetComponent<CharacterController>();


		CameraObj = Instantiate (CameraObjToInstantiate, thisTrans);
		CameraTrans = CameraObj.transform;



		switch (WitchChar) {
		case WitchCharacters.Runi:
			WitchModelObject = Instantiate (WitchModels[0], thisTrans);
			WitchModel = WitchModelObject.transform;
			thisAnim = WitchModelObject.GetComponent<Animator> ();
			break;

		case WitchCharacters.Loda:
			WitchModelObject = Instantiate (WitchModels[1], thisTrans);
			WitchModel = WitchModelObject.transform;
			thisAnim = WitchModelObject.GetComponent<Animator> ();
			break;

		case WitchCharacters.Faye:
			WitchModelObject = Instantiate (WitchModels[2], thisTrans);
			WitchModel = WitchModelObject.transform;
			thisAnim = WitchModelObject.GetComponent<Animator> ();
			break;

		case WitchCharacters.SugarSpice:
			WitchModelObject = Instantiate (WitchModels[3], thisTrans);
			WitchModel = WitchModelObject.transform;
			thisAnim = WitchModelObject.GetComponent<Animator> ();
			break;

		case WitchCharacters.Ricky:
			WitchModelObject = Instantiate (WitchModels[4], thisTrans);
			WitchModel = WitchModelObject.transform;
			thisAnim = WitchModelObject.GetComponent<Animator> ();
			break;

		case WitchCharacters.Atlas:
			WitchModelObject = Instantiate (WitchModels[5], thisTrans);
			WitchModel = WitchModelObject.transform;
			thisAnim = WitchModelObject.GetComponent<Animator> ();
			break;

		case WitchCharacters.Gretchen:
			WitchModelObject = Instantiate (WitchModels[6], thisTrans);
			WitchModel = WitchModelObject.transform;
			thisAnim = WitchModelObject.GetComponent<Animator> ();
			break;

		case WitchCharacters.Jewel:
			WitchModelObject = Instantiate (WitchModels[7], thisTrans);
			WitchModel = WitchModelObject.transform;
			thisAnim = WitchModelObject.GetComponent<Animator> ();
			break;
		}


	}

	void FixedUpdate() {


		if (Input.GetKeyDown ("0")) {
			FrontCamShow = !FrontCamShow;
			FrontCamera.SetActive (FrontCamShow);
		}



		moveDirection = new Vector3 (0, 0, 0);
		if (controller.isGrounded) {
			

		}


		// if (Input.GetAxis ("Horizontal") == 0) {
		if (Input.GetAxis ("Brake") == 0 && Momentum == 0) {
			if (speed < topSpeed)
				speed = speed + (Acceleration * Time.deltaTime);
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





		thisTrans.Rotate (0, Input.GetAxis ("Horizontal") * (rotSpeed - ((speed - TurnSpeedDec) / topSpeed)*150) * Time.deltaTime, 0);
		//if (Input.GetAxis ("Accelerate") < 0)
		if ((speed / topSpeed) < 0.5f) {
		//	thisTrans.Rotate (0, Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime*0.25f, 0);
		}



		// TurnFl = Mathf.Lerp (TurnFl, Input.GetAxis ("Horizontal"), Time.deltaTime * 3);
		TurnFl = WitchTiltAngle/WitchTiltAngleMax;



		AccelFl = speed / topSpeed;

		thisAnim.SetFloat ("Turn", TurnFl);
		thisAnim.SetFloat ("Accel", AccelFl);






		if (Input.GetAxis ("Horizontal") != 0) {
			if (TurnSpeedDec < speed)
				TurnSpeedDec += Time.deltaTime*12000;
			else
				TurnSpeedDec = speed;
			if (TurnSpeedDec == speed) {
				if (Momentum == 0) {
		//			VelocitySave = controller.velocity;
					Momentum = 1;
				}
			}

			if (Momentum == 1) {
		//		VelocitySave = new Vector3 (Mathf.Lerp (VelocitySave.x, 0, Time.deltaTime * 0.4f), VelocitySave.y, Mathf.Lerp (VelocitySave.z, 0, Time.deltaTime * 0.4f));
		//		moveDirection = new Vector3(VelocitySave.x, moveDirection.y, VelocitySave.z);
			}

		} else {
//			if (TurnSpeedDec > 0)
//				TurnSpeedDec -= Time.deltaTime*12000;
//			else
//				TurnSpeedDec = 0;
			TurnSpeedDec = 0;
			Momentum = 0;
		}




		if (Input.GetButtonDown ("Fly")) {
			if (flySpeed < 0)
				flySpeed = 0;
		}












		if (Input.GetAxis ("Horizontal") > 0) {
			if (WitchTiltAngle < WitchTiltAngleMax) {
				if (WitchTiltAngle < 0) WitchTiltAngle += Time.deltaTime * WitchTiltAngleSpeed;

				WitchTiltAngle += Time.deltaTime * WitchTiltAngleSpeed;
			}
			else
				WitchTiltAngle = WitchTiltAngleMax;
		} else if (Input.GetAxis ("Horizontal") < 0) {
			if (WitchTiltAngle > -WitchTiltAngleMax) {
				if (WitchTiltAngle > 0) WitchTiltAngle -= Time.deltaTime * WitchTiltAngleSpeed;
				WitchTiltAngle -= Time.deltaTime * WitchTiltAngleSpeed;
			}
			else
				WitchTiltAngle = -WitchTiltAngleMax;
		} else {
			if (WitchTiltAngle >= -45 && WitchTiltAngle < -1) {
				WitchTiltAngle += Time.deltaTime * WitchTiltAngleSpeed * 2;
			} else if (WitchTiltAngle <= 45 && WitchTiltAngle > 1) {
				WitchTiltAngle -= Time.deltaTime * WitchTiltAngleSpeed * 2;
			} else
				WitchTiltAngle = 0;
		}



		if (controller.isGrounded == false) {
			WitchModel.localEulerAngles = new Vector3 (-flySpeed / 9f, WitchModel.localEulerAngles.y, WitchModel.localEulerAngles.z);

		}
		else WitchModel.localEulerAngles = new Vector3 (Mathf.Lerp(WitchModel.localEulerAngles.x, 0, Time.deltaTime*3), WitchModel.localEulerAngles.y, WitchModel.localEulerAngles.z);





		WitchModel.localEulerAngles = new Vector3 (WitchModel.localEulerAngles.x, WitchTiltAngle, -WitchTiltAngle/3);










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

		if (controller.isGrounded == false) {
			if (CameraYTilt < 15)
				CameraYTilt += Time.deltaTime*15f;
			else
				CameraYTilt = 15;

			
		} else {
//			if (CameraYTilt > 0)
//				CameraYTilt -= Time.deltaTime*50f;
//			else
//				CameraYTilt = 0;

			CameraYTilt = Mathf.Lerp (CameraYTilt, 0, Time.deltaTime * 7f);
		}


		CameraYRaise=CameraYTilt/4;
		CameraTarget.localEulerAngles = new Vector3 (CameraYTilt, CameraTarget.localEulerAngles.y, CameraTarget.localEulerAngles.z);
		// CameraTrans.eulerAngles = new Vector3 (Mathf.Lerp(CameraTrans.eulerAngles.x, thisTrans.eulerAngles.x, Time.deltaTime*5), CameraTrans.eulerAngles.y, Mathf.Lerp(CameraTrans.eulerAngles.z, Input.GetAxis ("Horizontal")*5f, Time.deltaTime*4));
		CameraTrans.rotation = new Quaternion( Mathf.Lerp(CameraTrans.rotation.x, CameraTarget.rotation.x, Time.deltaTime*CameraRotSpeed), Mathf.Lerp(CameraTrans.rotation.y, CameraTarget.rotation.y, Time.deltaTime*CameraRotSpeed), Mathf.Lerp(CameraTrans.rotation.z, CameraTarget.rotation.z, Time.deltaTime*CameraRotSpeed), Mathf.Lerp(CameraTrans.rotation.w, CameraTarget.rotation.w, Time.deltaTime*CameraRotSpeed) );
		// Mathf.Lerp(CameraTrans.position.y, CameraTarget.position.y, Time.deltaTime*(CameraSpeed/2f))
			CameraTrans.position = new Vector3( Mathf.Lerp(CameraTrans.position.x, CameraTarget.position.x, Time.deltaTime*CameraSpeed), Mathf.Lerp(CameraTrans.position.y, CameraTarget.position.y+CameraYRaise, Time.deltaTime*(CameraSpeed*2f)), Mathf.Lerp(CameraTrans.position.z, CameraTarget.position.z, Time.deltaTime*CameraSpeed) );
		if (controller.isGrounded == false)
			BobbingMode = 1;
		
			switch (BobbingMode) {
			case 0:	
				if (BobbingHeight < 1)
					BobbingHeight += Time.deltaTime * BobbingSpeed;
				else
					BobbingMode = 1;
				break;
			case 1:
				if (BobbingHeight > 0)
					BobbingHeight -= Time.deltaTime * BobbingSpeed;
				else
					BobbingMode = 0;

				break;
			}


		WitchModel.position = new Vector3 (WitchModel.position.x, thisTrans.position.y + BobbingHeight, WitchModel.position.z);

	}


	void OnControllerColliderEnter(ControllerColliderHit hit){
		if (hit.gameObject.tag == "BoostRing"){
			SpeedBoost = BoostActualTopSpeed;
			Debug.Log ("hit!");
		}
	}


}
