using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCarUserController : MonoBehaviour {
	Vector3  Car_EulerAngleVelocity;
	Vector3 Volant_EulerAngleVelocity;
	Vector3 Car_PositionVelocity;
	Rigidbody Car_RG;
	public static Vector3 CarPosition;
	public GameObject wheels;
	public GameObject VolantGameObject;
	//CarController mCar;
	float ancemb = 0, nvemb=0;
	public float Accel;
	public float handbrake;
	public float Volant;
	public float speedo;
	public float rot ;
	public float emb ;
	float timeLeft = 10.0f;
	public static bool mode ; //true marcharrie false avant 
	public int gear ;
	public bool push  ;
	public float hoverForce;
	public float hoverHeight;
	void Start () {
	//	Car_EulerAngleVelocity = new Vector3 (GetComponent<Rigidbody>().rotation.eulerAngles.x, GetComponent<Rigidbody>().rotation.eulerAngles.y, GetComponent<Rigidbody>().rotation.eulerAngles.z);
		hoverHeight= 0.40f;
		hoverForce = 20f;
		Volant_EulerAngleVelocity = new Vector3 (VolantGameObject.GetComponent<Rigidbody>().rotation.eulerAngles.x, VolantGameObject.GetComponent<Rigidbody>().rotation.eulerAngles.y, VolantGameObject.GetComponent<Rigidbody>().rotation.eulerAngles.z);

		Car_EulerAngleVelocity = new Vector3 (Car_RG.rotation.eulerAngles.x, Car_RG.rotation.eulerAngles.y+3f, Car_RG.rotation.eulerAngles.z);
	//	Car_PositionVelocity = new Vector3 (this.GetComponent<Rigidbody> ().position.x, this.GetComponent<Rigidbody> ().position.y, this.GetComponent<Rigidbody> ().position.z ); 

	}
	void Awake (){
		Car_RG = GetComponent<Rigidbody> ();
	}
	void update(){

	/*	Volant =  Input.GetAxis ("Volant");
		Accel	 = 		Input.GetAxis ("Acelerator");
		float emb =		Input.GetAxisRaw ("embrayage");
		handbrake = 	Input.GetAxisRaw ("handbrake");
		mode = 			Input.GetButton ("marchearriere");*/
	}
	void FixedUpdate () {
		Volant =  Input.GetAxis ("Volant");
		Accel	 = 		Input.GetAxis ("Acelerator");
		 emb =		Input.GetAxisRaw ("embrayage");
		handbrake = 	Input.GetAxisRaw ("handbrake");
		mode = 			Input.GetButton ("marchearriere");
		Ray ray = new Ray (transform.position, -transform.up);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, hoverHeight))
		{
			print ("raycasittttttttttttttttt hit    karehba a aaaa"); 
			float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
			Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
			Car_RG.AddForce(appliedHoverForce, ForceMode.Acceleration);
		}

	
		if (SpeedIndicatorBehaviour.gear1) {
			
			gear = 1;
		}
		if (SpeedIndicatorBehaviour.gear2) {
			gear = 2;
		}
		if (SpeedIndicatorBehaviour.gear3) {

			gear = 3;
		}
		if (SpeedIndicatorBehaviour.gear4) {
			gear = 4;
		}
		if ((handbrake >=-1 )&& (handbrake <0)) {
			push = false;
		

		} else {
			push = true;

		}
		if (!mode) {
			if (!MainCarUserController.mode) {

				switch (gear) {
				case 1:

					Move_Car (Accel, handbrake, 13f);
					break;

				case 2:
					Move_Car (Accel*2, handbrake, 23f);
					break;
				case 3:
					Move_Car (Accel*3, handbrake, 30f);
					break;
				case 4:
					Move_Car (Accel*4, handbrake, 40f);
					break;
				case 5:
					Move_Car (Accel*5, handbrake, 50f);
					break;


				}


				rot = Volant * 2; 
				///rotation du volant 
				if (Volant > 0) {
					Quaternion deltaRotation = Quaternion.Euler (new Vector3 (Volant_EulerAngleVelocity.x, 0, Volant_EulerAngleVelocity.z * Time.deltaTime * rot * 1000f));
					VolantGameObject.GetComponent<Rigidbody> ().rotation = deltaRotation;
				} else if (Volant < 0) {
					Quaternion deltaRotation = Quaternion.Euler (new Vector3 (Volant_EulerAngleVelocity.x, 0, Volant_EulerAngleVelocity.z * Time.deltaTime * rot * 1000f));
					VolantGameObject.GetComponent<Rigidbody> ().rotation = deltaRotation;
				} else {
					Quaternion deltaRotation = Quaternion.Euler (new Vector3 (Volant_EulerAngleVelocity.x, 0, Volant_EulerAngleVelocity.z * Time.deltaTime * rot * 1000f + 1f));
					VolantGameObject.GetComponent<Rigidbody> ().rotation = deltaRotation;
				//	print ("hedha el volaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaannnnnnnnnnnnnnnnnnt");


				}
			/// rotation Car 


		


			} else {
				//arreiere 



			}
				
		}

	}

	void Move_Car(float Accel, float handbrake, float forceAdded) {


		if ( (Accel < 0 ) && push ){ 
		//	push = true;
			handbrake = 0;
			Car_RG.AddRelativeForce(0f, 0f, Accel * forceAdded);
			Car_RG.AddRelativeTorque(0f, Volant *3.5f, 0f);
		
		} else if ((Accel > 0)&& push)  {

			Car_RG.AddRelativeForce(0f, 0f, -Accel * forceAdded-20f);
			Car_RG.AddRelativeTorque(0f, Volant *3.5f, 0f);


		}


		if (Volant > 0) {

			Quaternion deltaRotationCar = Quaternion.Euler (new Vector3 (Car_EulerAngleVelocity.x, Car_EulerAngleVelocity.y * 0.5f * Time.deltaTime * Volant * 1000f, Car_EulerAngleVelocity.z));
			GetComponent<Rigidbody> ().rotation = deltaRotationCar;

		} else if (Volant < 0) {
			Quaternion deltaRotationCar = Quaternion.Euler (new Vector3 (Car_EulerAngleVelocity.x, Car_EulerAngleVelocity.y * 0.5f * Time.deltaTime * Volant * 1000f, Car_EulerAngleVelocity.z));
			GetComponent<Rigidbody> ().rotation = deltaRotationCar;
			//GetComponent<CarController> ().Move (Volant, Accel, handbrake, 0);

		}


}
}
