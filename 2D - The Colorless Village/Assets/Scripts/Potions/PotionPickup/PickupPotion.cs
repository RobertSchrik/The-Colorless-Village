using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPotion : MonoBehaviour {

    private Inventory inventory;
    public GameObject itemButton;

	void Start () {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
	}

	//On pickup set isfull slot to true so no other item can get in
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            for (int i = 0; i < inventory.slots.Length; i++){
                if (inventory.isFull[i] == false){
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
