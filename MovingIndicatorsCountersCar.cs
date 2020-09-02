using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingIndicators : MonoBehaviour {
	public GameObject rpmIndicator;
	public GameObject kmIndicator;
	public GameObject fuelIndicator;
	public GameObject tempratureIndicator;

	// Use tspeedis for initialization
	void Start () {

		var anglesInitial = transform.rotation.eulerAngles;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		var angles = transform.rotation.eulerAngles;
		angles.x += Time.deltaTime * 10;
		transform.rotation = Quaternion.Euler(angles);

	}
}
