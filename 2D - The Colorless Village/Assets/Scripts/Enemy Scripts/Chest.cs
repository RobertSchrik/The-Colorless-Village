using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour{

    public int health;

    private Animator anim;

    public static bool itemSpawn;
    public static bool spawnItem;
    public static bool multipleItems;
    public static float whichItem;

    private GameObject healthPotion;
    private GameObject damagePotion;
    private GameObject defencePotion;
    private GameObject speedPotion;
    private bool testUpdate;

    private bool flashActive;
    public float flashLength;
    public float timeToSmash;

    private float flashCounter;
    private SpriteRenderer ChestSprite;

    void Start(){
        ChestSprite = GetComponent<SpriteRenderer>();

        itemSpawn = false;
        spawnItem = false;
        testUpdate = false;
        spawnItem = ChestItemSpawn.spawnItem;
        
        whichItem = ChestItemSpawn.whichItem;
        multipleItems = ChestItemSpawn.multipleItems;

        healthPotion = GameObject.Find("HealthPotion");
        damagePotion = GameObject.Find("DamagePotion");
        defencePotion = GameObject.Find("DefencePotion");
        speedPotion = GameObject.Find("SpeedPotion");
    }

    //Destroy chest if health is 0
    void FixedUpdate(){
        if (health <= 0 && flashActive == false){
            
            itemSpawn = true;
            spawnItem = ChestItemSpawn.spawnItem;
            whichItem = ChestItemSpawn.whichItem;
            multipleItems = ChestItemSpawn.multipleItems;
                if (spawnItem == true && whichItem == 1 && multipleItems == false) {
                        Instantiate (healthPotion, transform.position, healthPotion.transform.rotation);
                            ChestItemSpawn.spawnItem = false;
                            if (multipleItems == false) {
                                testUpdate = true;
                            }
                }
                if (spawnItem == true && whichItem == 2 && multipleItems == false) {
                        Instantiate (damagePotion, transform.position, damagePotion.transform.rotation);
                            ChestItemSpawn.spawnItem = false;
                            if (multipleItems == false) {
                                testUpdate = true;
                            }
                }
                if (spawnItem == true && whichItem == 3 && multipleItems == false) {
                        Instantiate (defencePotion, transform.position, defencePotion.transform.rotation);
                            ChestItemSpawn.spawnItem = false;
                            if (multipleItems == false) {
                                testUpdate = true;
                            }
                }
                if (spawnItem == true && whichItem == 4 && multipleItems == false) {
                        Instantiate (speedPotion, transform.position, speedPotion.transform.rotation);
                            ChestItemSpawn.spawnItem = false;
                            if (multipleItems == false) {
                                testUpdate = true;
                            }
                }
                    if (spawnItem == true && whichItem == 1 && multipleItems == true) {
                            Instantiate (healthPotion, transform.position, healthPotion.transform.rotation);
                                if (ChestItemSpawn.whichItem2 == 1) {
                                    Instantiate (healthPotion, transform.position, healthPotion.transform.rotation);
                                }
                                if (ChestItemSpawn.whichItem2 == 2) {
                                    Instantiate (damagePotion, transform.position, damagePotion.transform.rotation);
                                }
                                if (ChestItemSpawn.whichItem2 == 3) {
                                    Instantiate (defencePotion, transform.position, defencePotion.transform.rotation);
                                }
                                if (ChestItemSpawn.whichItem2 == 4) {
                                    Instantiate (speedPotion, transform.position, speedPotion.transform.rotation);
                                }

                            Debug.Log(ChestItemSpawn.whichItem2);
                            ChestItemSpawn.spawnItem = false;
                            testUpdate = true;
                            ChestItemSpawn.multipleItems = false;
                    }
                    if (spawnItem == true && whichItem == 2 && multipleItems == true) {
                            Instantiate (damagePotion, transform.position, damagePotion.transform.rotation);
                                if (ChestItemSpawn.whichItem2 == 1) {
                                    Instantiate (healthPotion, transform.position, healthPotion.transform.rotation);
                                }
                                if (ChestItemSpawn.whichItem2 == 2) {
                                    Instantiate (damagePotion, transform.position, damagePotion.transform.rotation);
                                }
                                if (ChestItemSpawn.whichItem2 == 3) {
                                    Instantiate (defencePotion, transform.position, defencePotion.transform.rotation);
                                }
                                if (ChestItemSpawn.whichItem2 == 4) {
                                    Instantiate (speedPotion, transform.position, speedPotion.transform.rotation);
                                }

                            Debug.Log(ChestItemSpawn.whichItem2);
                            ChestItemSpawn.spawnItem = false;
                            testUpdate = true;
                            ChestItemSpawn.multipleItems = false;
                    }
                    if (spawnItem == true && whichItem == 3 && multipleItems == true) {
                            Instantiate (defencePotion, transform.position, defencePotion.transform.rotation);
                                if (ChestItemSpawn.whichItem2 == 1) {
                                    Instantiate (healthPotion, transform.position, healthPotion.transform.rotation);
                                }
                                if (ChestItemSpawn.whichItem2 == 2) {
                                    Instantiate (damagePotion, transform.position, damagePotion.transform.rotation);
                                }
                                if (ChestItemSpawn.whichItem2 == 3) {
                                    Instantiate (defencePotion, transform.position, defencePotion.transform.rotation);
                                }
                                if (ChestItemSpawn.whichItem2 == 4) {
                                    Instantiate (speedPotion, transform.position, speedPotion.transform.rotation);
                                }

                            Debug.Log(ChestItemSpawn.whichItem2);
                            ChestItemSpawn.spawnItem = false;
                            testUpdate = true;
                            ChestItemSpawn.multipleItems = false;
                    }
                    if (spawnItem == true && whichItem == 4 && multipleItems == true) {
                            Instantiate (speedPotion, transform.position, speedPotion.transform.rotation);
                                if (ChestItemSpawn.whichItem2 == 1) {
                                    Instantiate (healthPotion, transform.position, healthPotion.transform.rotation);
                                }
                                if (ChestItemSpawn.whichItem2 == 2) {
                                    Instantiate (damagePotion, transform.position, damagePotion.transform.rotation);
                                }
                                if (ChestItemSpawn.whichItem2 == 3) {
                                    Instantiate (defencePotion, transform.position, defencePotion.transform.rotation);
                                }
                                if (ChestItemSpawn.whichItem2 == 4) {
                                    Instantiate (speedPotion, transform.position, speedPotion.transform.rotation);
                                }

                            Debug.Log(ChestItemSpawn.whichItem2);
                            ChestItemSpawn.spawnItem = false;
                            testUpdate = true;
                            ChestItemSpawn.multipleItems = false;
                    }


                if (testUpdate == true) {
                    Destroy(gameObject);
                    testUpdate = false;
                }
        }
        StartCoroutine(TakeFlash());
    }

    //Damage recieved
    public void TakeDamage(int damage){
        health -= damage;
        flashActive = true;
        flashCounter = flashLength;
    }


    private IEnumerator TakeFlash(){
        if (flashActive == true){
            yield return new WaitForSeconds(timeToSmash);
            if (flashCounter > flashLength * .50f){
                ChestSprite.color = new Color(0, 0, 0, 255);
            }
            else if (flashCounter < 0){
                ChestSprite.color = new Color(191, 176, 158, 255);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }
}