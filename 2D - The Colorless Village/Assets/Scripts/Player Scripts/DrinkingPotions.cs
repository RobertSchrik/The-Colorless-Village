using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkingPotions : MonoBehaviour {

	public static float maxActivePotions;
	
	// Use this for initialization
	void Start () {
		maxActivePotions = 0;
	}
	
	// Update is called once per frame
	void Update () {
		maxActivePotions = maxActivePotions;
		if (Input.GetKeyDown(KeyCode.Alpha0)) {
			Debug.Log(maxActivePotions);
		}
	}
}
