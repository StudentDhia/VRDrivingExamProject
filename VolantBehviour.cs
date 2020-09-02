using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolantBehviour : MonoBehaviour {
	public float rot ;
	public float speedo ; 
	Vector3 Car_EulerAngleVelocity;  
	// Use this for initialization
	void Start () {
		Car_EulerAngleVelocity = new Vector3 (GetComponent<Rigidbody>().rotation.eulerAngles.x, GetComponent<Rigidbody>().rotation.eulerAngles.y, GetComponent<Rigidbody>().rotation.eulerAngles.z);
		speedo = 10f;
	}

	// Update is called once per frame
	void FixedUpdate () {

	
		float h =  Input.GetAxis ("Volant");
		rot = h*2; 
		if (h > 0 ) {
			GetComponent<Rigidbody>().AddRelativeTorque(0f, 0f, h*3.5f);
		/*	Quaternion deltaRotation = Quaternion.Euler(new Vector3(Car_EulerAngleVelocity.x,Car_EulerAngleVelocity.y , Car_EulerAngleVelocity.z * Time.deltaTime*rot*1000f  ) );
			GetComponent<Rigidbody>().rotation = deltaRotation;
		//	transform.Rotate (new Vector3 (0, 0, transform.eulerAngles.z * h + Time.deltaTime));*/
		} else if (h < 0) {
			GetComponent<Rigidbody>().AddRelativeTorque(0f, 0f, h*3.5f);
			/*Quaternion deltaRotation = Quaternion.Euler(new Vector3(Car_EulerAngleVelocity.x,Car_EulerAngleVelocity.y , Car_EulerAngleVelocity.z * Time.deltaTime*rot*1000f  ) );
			GetComponent<Rigidbody>().rotation = deltaRotation;*/
		} else {
			Quaternion deltaRotation = Quaternion.Euler(new Vector3(Car_EulerAngleVelocity.x,Car_EulerAngleVelocity.y  , Car_EulerAngleVelocity.z * Time.deltaTime*rot*1000f+1f  ) );
			GetComponent<Rigidbody>().rotation = deltaRotation;
			print ("hedha el volaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaannnnnnnnnnnnnnnnnnt");
		
			
		}
	
		//&& h <= 1
		
	}
}
//transform.eulerAngles.z 