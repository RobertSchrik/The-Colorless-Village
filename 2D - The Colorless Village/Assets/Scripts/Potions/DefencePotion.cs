using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefencePotion : MonoBehaviour {

	public int defencePotion;
	public bool drinkPotion;
	public float potionTimer;
	public float potionCooldown;

	public static bool defenceItem;

	// Use this for initialization
	void Start () {
		
		defencePotion = 10;
		drinkPotion = false;

		defenceItem = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (drinkPotion == true && DrinkingPotions.maxActivePotions > 3 || potionCooldown > 0) {
			drinkPotion = false;
		}

		if (drinkPotion == true && DrinkingPotions.maxActivePotions < 3 && potionCooldown <= 0) {
			Player_DamageTaken.Armor += defencePotion;
			drinkPotion = false;
			defenceItem = true;
			potionTimer = 15;
			potionCooldown = 45;
			DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions + 1;
		}

		if (potionCooldown > 0) {
			potionCooldown -= Time.deltaTime;
			if (potionCooldown <= 0) {
				DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions - 1;
			}
		}

		if (potionTimer > 0) {
			potionTimer -= Time.deltaTime;
			if (potionTimer <= 0) {
				Player_DamageTaken.Armor -= defencePotion;
				defenceItem = false;
			}
		}
	}
}
