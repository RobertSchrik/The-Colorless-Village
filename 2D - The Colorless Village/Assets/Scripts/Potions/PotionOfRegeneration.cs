using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionOfRegeneration : MonoBehaviour {

	public float regenerationPotion;
	public bool drinkPotion;
	public static float potionTimer;
	public float potionCooldown;

	public static bool healingItem;
	public static bool potionFinished;
	public static bool playParticles;

	// Use this for initialization
	void Start () {
		regenerationPotion = 0.1f;
		
		drinkPotion = false;

		healingItem = false;

		potionFinished = false;

		playParticles = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (drinkPotion == true && DrinkingPotions.maxActivePotions > 3 || potionCooldown > 0) {
			drinkPotion = false;
		}

		if (drinkPotion == true && DrinkingPotions.maxActivePotions < 3 && potionCooldown <= 0) {
			drinkPotion = false;
			healingItem = true;
			playParticles = true;
			potionTimer = 10;
			potionCooldown = 60;
			DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions + 1;
		}

		if (potionCooldown > 0) {
			potionCooldown -= Time.deltaTime;
			if (potionCooldown <= 0) {
				potionFinished = true;
			}
		}

		if (potionTimer > 0) {
			potionTimer -= Time.deltaTime;
			Player_DamageTaken.Health += regenerationPotion;
			if (potionTimer <= 0) {
				healingItem = false;
			}
		}
		if (potionFinished == true) {
			DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions - 1;
			potionFinished = false;
		}
	}
}
