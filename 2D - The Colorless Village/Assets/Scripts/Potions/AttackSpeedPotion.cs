using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedPotion : MonoBehaviour {

	public float attackSpeedPotion;
	public static bool drinkPotion;
	public float potionTimer;
	public float potionCooldown;

	public bool attackSpeedItem;

	// Use this for initialization
	void Start () {
		attackSpeedPotion = 0.6f;
		drinkPotion = false;

		attackSpeedItem = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (drinkPotion == true && DrinkingPotions.maxActivePotions > 3 || potionCooldown > 0) {
			drinkPotion = false;
		}

		if (drinkPotion == true && DrinkingPotions.maxActivePotions < 3 && potionCooldown <= 0) {
			Player_Attack.AttackCooldownStart -= attackSpeedPotion;
			attackSpeedItem = true;
			potionTimer = 10;
			potionCooldown = 120;
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
				Player_Attack.AttackCooldownStart += attackSpeedPotion;
				attackSpeedItem = false;
			}
		}
	}
}
