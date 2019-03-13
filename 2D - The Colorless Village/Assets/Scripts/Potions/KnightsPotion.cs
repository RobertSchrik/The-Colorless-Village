using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightsPotion : MonoBehaviour {

	public int damagePotion;
	public int defencePotion;
	public static bool drinkPotion;
	public float potionTimer;
	public float potionCooldown;
	public bool potionFinished;

	public bool damageItem;

	// Use this for initialization
	void Start () {
		
		damagePotion = 15;
		defencePotion = 10;
		drinkPotion = false;
		potionFinished = false;

		potionTimer = 0;

		damageItem = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (drinkPotion == true && DrinkingPotions.maxActivePotions < 3 && potionCooldown <= 0) {
			Player_Attack.damage += damagePotion;
			Player_DamageTaken.Armor += defencePotion;
			damageItem = true;
			potionTimer = 20;
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
			if (potionTimer <= 0) {
				Player_Attack.damage -= damagePotion;
				Player_DamageTaken.Armor -= defencePotion;
				damageItem = false;
			}
		}

		if (potionFinished == true) {
			DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions - 1;
			potionFinished = false;
		}
	}
}