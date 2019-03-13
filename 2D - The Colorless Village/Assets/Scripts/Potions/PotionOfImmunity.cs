using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionOfImmunity : MonoBehaviour {

	public bool drinkPotion;
	public static bool shield;

	// Use this for initialization
	void Start () {
		shield = false;
		drinkPotion = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (drinkPotion == true && Player_DamageTaken.shieldActive == true || DrinkingPotions.maxActivePotions > 3) {
			drinkPotion = false;
		}

		if (drinkPotion == true && Player_DamageTaken.shieldActive == false && DrinkingPotions.maxActivePotions < 3) {
			drinkPotion = false;
			shield = true;
			Player_DamageTaken.shieldActive = true;
			Player_DamageTaken.activeTime = 0.5f;
			DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions + 1;
		}
	}
}