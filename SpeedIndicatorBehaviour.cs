using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIndicatorBehaviour : MonoBehaviour {

	float MaxRotation = 0;
	//Mode =1 true Marche en avant  et -1 en arriere (reverse gear , forward march) et 0 point mort 
//	public int   Mode = 1  ;
	public static  bool    gear1   ;
	public static bool    gear2   ;
	public static bool    gear3   ;
	public static bool    gear4   ;
	// les 5 vitesses + R =-1 marche en arriere + point mort 0
	public  int   gear = 0;
	Quaternion target1;
	Quaternion target2;
	Quaternion target3;
	Quaternion target4;
	Quaternion target5;

	//Km/h
	public float speed;

	private float rpm;


	// Use this for initialization+
	void Start () {
		Debug.Log("rotatin of indicator " + transform.rotation);
		Debug.Log("position of indicator " +transform.position);
		Debug.Log ("transform.eulerAngles"+transform.eulerAngles);

		transform.eulerAngles = new Vector3(-20.32f,  transform.eulerAngles.y, transform.eulerAngles.z);
		Debug.Log ("transform.eulerAngles2"+transform.eulerAngles);

	}

	// Update is called once per frame
	void Update () {
		//vertical = embrayage
		///float h =  Input.GetAxis ("Vertical");
		///float v = CrossPlatformInputManager.GetAxis("Vertical");
		/// Horizontal volant

		float h =  Input.GetAxis ("Acelerator");
		gear1 = Input.GetButton("1ere");
		gear2 = Input.GetButton("2eme");
		gear3 = Input.GetButton("3eme");
		gear4 = Input.GetButton("4eme");

	
		speed = h;



		if (gear1) {
			
			gear = 1;
		}
		if (gear2) {

			gear = 2;
		}
		if (gear3) {
			gear = 3;
		}
		if (gear4) {
			
			gear = 4;
		}
	
		if (!MainCarUserController.mode ) {

			switch (gear) {
			case 1:
				
			
			
				Debug.Log("transform.eulerAngles"+transform.eulerAngles.z);


				//if(speed>0){ speed = -speed;}
				Quaternion Initial = Quaternion.Euler (-11.32f,transform.eulerAngles.y, transform.eulerAngles.z);

				target1 = Quaternion.Euler ( (transform.eulerAngles.x* 45f), transform.eulerAngles.y,transform.eulerAngles.z);
					transform.rotation = Quaternion.Slerp (Initial, target1, Time.deltaTime * 15f);


			//		Debug.Log ("Swith the gear please go to 2");



				break;

			case 2:
					if(speed>0){ speed = -speed;}

				target2 = Quaternion.Euler ( (h * 60f),transform.eulerAngles.y ,transform.eulerAngles.z);
				transform.rotation = Quaternion.Slerp (target1, target2, Time.deltaTime * 30f);


					
				break;
			case 3:
				
				if(speed>0){ speed = -speed;}
				target3 = Quaternion.Euler ( (h * 80f),transform.eulerAngles.y ,transform.eulerAngles.z);
				transform.rotation = Quaternion.Slerp (target2, target3, Time.deltaTime * 60f);

			


				break;
			case 4:
				if(speed>0){ speed = -speed;}
				target4 = Quaternion.Euler ( (h * 120f),975 ,transform.eulerAngles.z);
				transform.rotation = Quaternion.Slerp (target3, target4, Time.deltaTime * 70);



				break;
			case 5:
				if(speed>0){ speed = -speed;}
				target4 = Quaternion.Euler ( (h * 180f),transform.eulerAngles.y ,transform.eulerAngles.z);
				transform.rotation = Quaternion.Slerp (target3, target4, Time.deltaTime * 120f);
				break;


			}




		} else if (MainCarUserController.mode ) {
			MaxRotation = 0;
			//Debug.Log ("MaxRotation"+MaxRotation); 
		} 





	}
}
