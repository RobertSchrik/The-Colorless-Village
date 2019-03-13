using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlusPotion : MonoBehaviour {
	
	public int damagePotion;
	public static bool drinkPotion;
	public float potionTimer;
	public float potionCooldown;

	public bool damageItem;

	// Use this for initialization
	void Start () {
		
		damagePotion = 25;
		drinkPotion = false;

		damageItem = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (drinkPotion == true && DrinkingPotions.maxActivePotions > 3 || potionCooldown > 0)
		
		if (drinkPotion == true && DrinkingPotions.maxActivePotions < 3 && potionCooldown <= 0) {
			Player_Attack.damage += damagePotion;
			damageItem = true;
			potionTimer = 20;
			potionCooldown = 120;
			DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions + 1;
		}

		if (potionCooldown > 0) {
			potionCooldown -= Time.deltaTime;
		}

		if (potionTimer > 0) {
			potionTimer -= Time.deltaTime;
			if (potionTimer <= 0) {
				Player_Attack.damage -= damagePotion;
				damageItem = false;
			}
		}
	}
}