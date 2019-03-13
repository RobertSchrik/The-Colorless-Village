using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreaterPotionOfHealth : MonoBehaviour {

	public float healthPotion;
	public bool drinkPotion;
	public float potionCooldown;

	public static bool healingItem;

	// Use this for initialization
	void Start () {

		healthPotion = 25;
		drinkPotion = false;
		
		healingItem = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (drinkPotion == true && Player_DamageTaken.Health >= 75) {
			drinkPotion = false;
		}
		if (drinkPotion == true && Player_DamageTaken.Health <= 75 && potionCooldown <= 0) {
			Player_DamageTaken.Health += healthPotion;
			drinkPotion = false;
			healingItem = true;
			potionCooldown += 10;
		}
	}
}
