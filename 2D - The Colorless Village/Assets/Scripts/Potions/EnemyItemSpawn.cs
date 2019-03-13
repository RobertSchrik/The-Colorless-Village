using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemSpawn : MonoBehaviour {

	public static bool itemSpawnChance;
	public static bool spawnItem;

	public float occurenceNothing;
	public float occurenceHealth;
	public bool found;

	private float counter;
	private float randomNumber;
	private float totalOccurence;
	
	// Use this for initialization
	void Start () {
	itemSpawnChance = Enemy.itemSpawn;
	
	totalOccurence = 0;
	totalOccurence += occurenceNothing;
	totalOccurence += occurenceHealth;
	}
	
	// Update is called once per frame
	void Update () {
	itemSpawnChance = Enemy.itemSpawn;

		if (itemSpawnChance == true) {
			randomNumber = Random.Range(0, totalOccurence);
			counter = 0;
			found = false;
			if (found == false) {
				counter += occurenceNothing;
				if (randomNumber <= counter) {
					spawnItem = false;
					Enemy.itemSpawn = false;
					found = true;
				}
			}
			if (found == false) {
				counter += occurenceHealth;
				if (randomNumber <= counter) {
					spawnItem = true;
					Enemy.itemSpawn = false;
					found = true;
				}
			}
		}
	}
}
