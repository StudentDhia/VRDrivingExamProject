using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TricolorFeuBehaviour : MonoBehaviour {
	public float elapsed = 0f;
	public GameObject redLight;
	public GameObject orangeLight;
	public GameObject greenLight;

	void Start () {
		
		redLight.SetActive (false);
		orangeLight.SetActive (false);
		greenLight.SetActive (false);
	}
	


	void Update() {
		elapsed += Time.deltaTime;
		orangeLight.SetActive (false);
		greenLight.SetActive (false);
		redLight.SetActive (true);
		if (elapsed >=30f){
			redLight.SetActive (false);
			orangeLight.SetActive (true);
		}
		if (elapsed >=35f){
			redLight.SetActive (false);
			orangeLight.SetActive (true);
		}
		if (elapsed >=40f){
			orangeLight.SetActive (false);
			greenLight.SetActive (true);
		}
	
	}

}