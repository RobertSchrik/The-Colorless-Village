using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestItemSpawn : MonoBehaviour {

	public static bool itemSpawnChance;
	public static bool spawnItem;
	public static bool multipleItems;
	public static float whichItem;
	public static float whichItem2;

	public float occurenceHealth;
	public float occurenceDamage;
	public float occurenceDefence;
	public float occurenceSpeed;
	public bool found;

	private float howManyItems;
	private float counter;
	private float randomNumber;
	private float totalOccurence;
	
	// Use this for initialization
	void Start () {
	itemSpawnChance = Chest.itemSpawn;
	multipleItems = false;
	howManyItems = 0;
	
	totalOccurence = 0;
	totalOccurence += occurenceHealth;
	totalOccurence += occurenceDamage;
	totalOccurence += occurenceDefence;
	totalOccurence += occurenceSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	itemSpawnChance = Chest.itemSpawn;		

		if (itemSpawnChance == true) {
			howManyItems = Random.Range(0, 10);
			if (howManyItems <= 1) {
				multipleItems = false;
			}
			if (howManyItems > 1) {
				multipleItems = true;
				whichItem2 = Random.Range(0, totalOccurence);
				Debug.Log(whichItem2);
				counter = 0;
				found = false;

				if (found == false) {
					counter += occurenceHealth;
					if (whichItem2 <= counter) {
						whichItem2 = 1;
						found = true;
					}
				}
				if (found == false) {
					counter += occurenceDamage;
					if (whichItem2 <= counter) {
						whichItem2 = 2;
						found = true;
					}
				}
				if (found == false) {
					counter += occurenceDefence;
					if (whichItem2 <= counter) {
						whichItem2 = 3;
						found = true;
					}
				}
				if (found == false) {
					counter += occurenceSpeed;
					if (whichItem2 <= counter) {
						whichItem2 = 4;
						found = true;
					}
				}
			}
		}

		if (itemSpawnChance == true) {
			randomNumber = Random.Range(0, totalOccurence);
			counter = 0;
			found = false;

			if (found == false) {
				counter += occurenceHealth;
				if (randomNumber <= counter) {
					whichItem = 1;
					spawnItem = true;
					Chest.itemSpawn = false;
					found = true;
				}
			}
			if (found == false) {
				counter += occurenceDamage;
				if (randomNumber <= counter) {
					whichItem = 2;
					spawnItem = true;
					Chest.itemSpawn = false;
					found = true;
				}
			}
			if (found == false) {
				counter += occurenceDefence;
				if (randomNumber <= counter) {
					whichItem = 3;
					spawnItem = true;
					Chest.itemSpawn = false;
					found = true;
				}
			}
			if (found == false) {
				counter += occurenceSpeed;
				if (randomNumber <= counter) {
					whichItem = 4;
					spawnItem = true;
					Chest.itemSpawn = false;
					found = true;
				}
			}
		}
	}
}
