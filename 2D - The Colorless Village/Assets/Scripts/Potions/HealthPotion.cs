using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour {

	public float healthPotion;
	public static bool drinkPotion;

	public static bool healingItem;
	public static bool playParticles;

	// Use this for initialization
	void Start () {

		healthPotion = 10;
		drinkPotion = false;

		healingItem = false;
		playParticles = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (drinkPotion == true && Player_DamageTaken.Health >= 90) {
			drinkPotion = false;
		}
		if (drinkPotion == true && Player_DamageTaken.Health <= 90) {
			Player_DamageTaken.Health += healthPotion;
			healingItem = true;
			drinkPotion = false;
			playParticles = true;
		}
	}
}
