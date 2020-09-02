using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpmIndicatorBehaviour : MonoBehaviour {
	int MaxRotation = 0;
	//Mode =1 true Marcspeede en avant  et -1 en arriere (reverse gear , forward marcspeed) et 0 point mort 
	public int   Mode = 1  ;

	// les 5 vitesses + R =-1 marcspeede en arriere + point mort 0
	public int gear = 0;


	//Km/speed
	public float speed;

	private float rpm;


	// Use tspeedis for initialization
	void Start () {
	//	Debug.Log("rotatin of indicator " + transform.rotation);
		//Debug.Log("position of indicator " +transform.position);
		//Debug.Log ("transform.eulerAngles"+transform.eulerAngles);

		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,  60);
	}
	
	// Update is called once per frame
	void Update () {
		
		float speed =  4*Input.GetAxis ("Horizontal");
		speed = speed;
		if (Mode == 1) {
			
			switch(gear) {
			case 1:
				MaxRotation = 113;


			//	if (speed > 0f && speed <= 20f) {
					
					//rpm de 0 vers 3 max 

		
				if (transform.eulerAngles.z + 2 * Time.time <= MaxRotation && speed <= 0.5f && speed > 0 ) {
					
					Quaternion target = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + speed * Time.time);
					transform.rotation = Quaternion.Slerp (transform.rotation, target, speed);

					//Debug.Log ("rotatin of indicator " + transform.rotation);

				} else  {

					if (transform.eulerAngles.z >=200 && speed<0 ) {
						Quaternion target = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 2 * Time.time);
						transform.rotation = Quaternion.Slerp (transform.rotation, target, speed);

						//Debug.Log ("rotatin of indicator moins " + speed);
					}
					/*MaxRotation = 200;
					Debug.Log ("speededaspeed else mte3le premierew spedd mrigla  " );

					if (transform.eulerAngles.z  <= MaxRotation  && speed>0  ) {
						Quaternion target = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 1 * Time.time);
						transform.rotation = Quaternion.Slerp (transform.rotation, target, speed);

						Debug.Log ("extrem damage  " + transform.rotation);

					} else {
						
						if (transform.eulerAngles.z >=200 && speed<0 ) {
						Quaternion target = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 2 * Time.time);
						transform.rotation = Quaternion.Slerp (transform.rotation, target, speed);

						Debug.Log ("rotatin of indicator moins " + speed);
						}
					}*/


					
				}

			

				;
				break;
				 
			case 2:
				if (speed > 20f && speed <= 30f) {

					//rpm de 0 vers 3 max 
					for (float i = 20f; i <= speed; i++) {
						print (i);
					} 

				}else {

				}

				;
				break;
			case 3:
				if (speed > 20f && speed <= 30f) {

					//rpm de 0 vers 3 max 
					for (float i = 20f; i <= speed; i++) {
						print (i);
					}

				}
				;
				break;
			case 4:
				if (speed > 20f && speed <= 30f) {

					//rpm de 0 vers 3 max 
					for (float i = 20f; i <= speed; i++) {
						print (i);
					}

				}
				;
				break;
		
			case 5:
				if (speed > 20f && speed <= 30f) {

					//rpm de 0 vers 3 max 
					for (float i = 20f; i <= speed; i++) {
						print (i);
					}

				}
				;
				break;
			

			}




		} else if (Mode == 0) {
			MaxRotation = 0;
			Debug.Log ("MaxRotation"+MaxRotation); 
		} else  if (Mode == -1) {
			MaxRotation = 200;
			Debug.Log ("MaxRotation"+MaxRotation); 
		}
	




	}
}
