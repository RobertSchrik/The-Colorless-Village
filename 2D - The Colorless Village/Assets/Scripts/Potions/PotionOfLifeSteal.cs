using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionOfLifeSteal : MonoBehaviour {

	public int lifeStealPotion;
	public int increasedDamage;
	public bool drinkPotion;
	public float potionTimer;
	public float potionCooldown;

	public static bool healingItem;
	public static bool playParticles;

	// Use this for initialization
	void Start () {

		lifeStealPotion = 1;
		drinkPotion = false;
		increasedDamage = 15;

		potionCooldown = 0;

		healingItem = false;
		playParticles = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (drinkPotion == true && potionCooldown > 0 || DrinkingPotions.maxActivePotions > 3) {
			drinkPotion = false;
		}

		if (drinkPotion == true && potionCooldown <= 0 && DrinkingPotions.maxActivePotions < 3) {
			drinkPotion = false;
			potionTimer = 10;
			potionCooldown += 50;
			playParticles = true;
			Player_Attack.damage += increasedDamage;
			DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions + 1;
		}

		if (potionTimer > 0) {
			potionTimer -= Time.deltaTime;
			if (Player_DamageTaken.Health <= 95 && Enemy.flashActive == true) {
				Player_DamageTaken.Health += lifeStealPotion;
				healingItem = true;
			}
			if (potionTimer <= 0) {
				Player_Attack.damage -= increasedDamage;
				healingItem = false;
				DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions - 1;
			}
		}

		if (potionCooldown > 0) {
			potionCooldown -= Time.deltaTime;
		}
	}
}
