using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionUse : MonoBehaviour {

	public float healthPotion;
	public static bool healingItem;

	public float potionTimer;
	public float potionCooldown;

	public int damagePotion;
	public static bool damageItem;

	public int defencePotion;
	public static bool defenceItem;

	public int speedPotion;
	public static bool speedItem;

	public float greaterHealthPotion;
	public static bool greaterHealingItem;

	//public static bool shield;

	public Player_Movement player;

	public float regenerationPotion;
	public static bool regenerationItem;

	public int damagePlusPotion;
	public static bool damagePlusItem;

	public int defencePlusPotion;
	public static bool defencePlusItem;

	public int speedPlusPotion;
	public static bool speedPlusItem;

	public static bool itemSpawnHealing;
	public static bool itemSpawnDamage;
	public static bool itemSpawnDefence;
	public static bool itemSpawnSpeed;

	private GameObject greaterPotionOfHealth;
	private GameObject damagePlusPlusPotion;
	private GameObject defencePlusPlusPotion;
	private GameObject potionOfSpeed;


	void Start () {

		healthPotion = 10;
		healingItem = false;

		damagePotion = 5;
		damageItem = false;

		defencePotion = 5;
		defenceItem = false;
		
		speedPotion = 2;
		speedItem = false;

		greaterHealthPotion = 25;
		greaterHealingItem = false;

		//shield = false;

		regenerationPotion = 0.1f;
		regenerationItem = false;

		damagePlusPotion = 25;
		damagePlusItem = false;

		defencePlusPotion = 10;
		defencePlusItem = false;

		speedPlusPotion = 5;
		speedPlusItem = false;

		itemSpawnHealing = false;
		itemSpawnDamage = false;
		itemSpawnDefence = false;
		itemSpawnSpeed = false;

		greaterPotionOfHealth = GameObject.Find("GreaterPotionOfHealth");
		damagePlusPlusPotion = GameObject.Find("DamagePlusPotion");
		defencePlusPlusPotion = GameObject.Find("DefencePlusPotion");
		potionOfSpeed = GameObject.Find("PotionOfSpeed");


		player = FindObjectOfType<Player_Movement> ();
	}
	void Update() {
		if (itemSpawnHealing == true) {
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.y);
        	Instantiate (greaterPotionOfHealth, transform.position, greaterPotionOfHealth.transform.rotation);
        	itemSpawnHealing = false;
		}
		if (itemSpawnDamage == true) {
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.y);
        	Instantiate (damagePlusPlusPotion, transform.position, damagePlusPlusPotion.transform.rotation);
        	itemSpawnDamage = false;
		}
		if (itemSpawnDefence == true) {
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.y);
        	Instantiate (defencePlusPlusPotion, transform.position, defencePlusPlusPotion.transform.rotation);
        	itemSpawnDefence = false;
		}
		if (itemSpawnSpeed == true) {
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.y);
        	Instantiate (potionOfSpeed, transform.position, potionOfSpeed.transform.rotation);
        	itemSpawnSpeed = false;
		}
	}

	public void UseDamage() {
		if (DrinkingPotions.maxActivePotions < 3 && potionCooldown <= 0) {
			Player_Attack.damage += damagePotion;
			damageItem = true;
			potionTimer = 15;
			potionCooldown = 35;
			DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions + 1;
			Destroy(gameObject);
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
				Player_Attack.damage -= damagePotion;
			}
		}
	}
	public void UseHealth() {
		if (Player_DamageTaken.Health <= 90) {
			Player_DamageTaken.Health += healthPotion;
			healingItem = true;
			Destroy(gameObject);
		}
	}
	public void UseDefence() {
		if (DrinkingPotions.maxActivePotions < 3 && potionCooldown <= 0) {
			Player_DamageTaken.Armor += defencePotion;
			defenceItem = true;
			potionTimer = 15;
			potionCooldown = 45;
			DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions + 1;
			Destroy(gameObject);
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
			}
		}
	}
	public void UseSpeed() {
		if (DrinkingPotions.maxActivePotions < 3 && potionCooldown <= 0) {
			Player_Movement.moveSpeed += speedPotion;
			speedItem = true;
			potionTimer = 25;
			potionCooldown = 55;
			DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions + 1;
			Destroy(gameObject);
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
	public void UseGreaterHealth() {
		if (Player_DamageTaken.Health <= 75 && potionCooldown <= 0) {
			Player_DamageTaken.Health += greaterHealthPotion;
			greaterHealingItem = true;
			potionCooldown += 10;
			Destroy(gameObject);
		}
	}
	/*public void UseShield() {
		if (Player_DamageTaken.shieldActive == false && DrinkingPotions.maxActivePotions < 3) {
			shield = true;
			Player_DamageTaken.shieldActive = true;
			Player_DamageTaken.activeTime = 0.5f;
			DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions + 1;
			Destroy(gameObject);
		}
	}*/
	/*public void UseRegeneration() {
		if (DrinkingPotions.maxActivePotions < 3 && potionCooldown <= 0) {
			regenerationItem = true;
			potionTimer = 10;
			potionCooldown = 60;
			DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions + 1;
			Destroy(gameObject);
		}

		if (potionCooldown > 0) {
			potionCooldown -= Time.deltaTime;
		}

		if (potionTimer > 0) {
			potionTimer -= Time.deltaTime;
			Player_DamageTaken.Health += regenerationPotion;
			if (potionTimer <= 0) {
				regenerationItem = false;
				DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions - 1;
			}
		}
	}*/
	public void UseDamagePlus() {
		if (DrinkingPotions.maxActivePotions < 3 && potionCooldown <= 0) {
			Player_Attack.damage += damagePlusPotion;
			damagePlusItem = true;
			potionTimer = 20;
			potionCooldown = 120;
			DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions + 1;
			Destroy(gameObject);
		}

		if (potionCooldown > 0) {
			potionCooldown -= Time.deltaTime;
		}

		if (potionTimer > 0) {
			potionTimer -= Time.deltaTime;
			if (potionTimer <= 0) {
				Player_Attack.damage -= damagePlusPotion;
				damageItem = false;
			}
		}
	}
	public void UseDefencePlus() {
		if (DrinkingPotions.maxActivePotions < 3 && potionCooldown <= 0) {
			Player_DamageTaken.Armor += defencePotion;
			defencePlusItem = true;
			potionTimer = 20;
			potionCooldown = 120;
			DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions + 1;
			Destroy(gameObject);
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
			}
		}
	}
	public void UseSpeedPlus() {
		if (DrinkingPotions.maxActivePotions < 3 && potionCooldown <= 0) {
			Player_Movement.moveSpeed += speedPotion;
			speedPlusItem = true;
			potionTimer = 25;
			potionCooldown = 55;
			DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions + 1;
			Destroy(gameObject);
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
	public void SpawnGreaterHealing() {
		itemSpawnHealing = true;
	}
	public void SpawnDamagePlus() {
		itemSpawnDamage = true;
	}
	public void SpawnDefencePlus() {
		itemSpawnDefence = true;
	}
	public void SpawnSpeedPlus() {
		itemSpawnSpeed = true;
	}
}
