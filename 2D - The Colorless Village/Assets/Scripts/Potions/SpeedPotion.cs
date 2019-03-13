using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour {

	public int speedPotion;
	public bool drinkPotion;
	public float potionTimer;
	public float potionCooldown;

	public static bool speedItem;

	// Use this for initialization
	void Start () {
		speedPotion = 2;
		drinkPotion = false;

		speedItem = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (drinkPotion == true && DrinkingPotions.maxActivePotions < 3 && potionCooldown <= 0) {
			Player_Movement.moveSpeed += speedPotion;
			drinkPotion = false;
			speedItem = true;
			potionTimer = 25;
			potionCooldown = 55;
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
				Player_Movement.moveSpeed -= speedPotion;
				speedItem = false;
			}
		}
	}
}