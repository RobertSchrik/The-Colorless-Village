using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    public int health;
    public float speed;

    private Animator anim;

    public static bool flashActive;
    public float flashLength;
    public float timeToSmash;

    public static bool itemSpawn;
    public static bool spawnItem;
    private static bool testupdate;

    private float flashCounter;
    private SpriteRenderer EnemySprite;
    private GameObject healthPotion;

    void Start(){
        EnemySprite = GetComponent<SpriteRenderer>();
        itemSpawn = false;
        spawnItem = false;
        testupdate = false;
        spawnItem = EnemyItemSpawn.spawnItem;

        healthPotion = GameObject.Find("HealthPotion");
    }

    //Enemy Health destroy if health is 0
    void FixedUpdate (){
        if (health <= 0){
        	itemSpawn = true;
        	spawnItem = EnemyItemSpawn.spawnItem;
        		if (spawnItem == true) {
        			Instantiate (healthPotion, transform.position, healthPotion.transform.rotation);
        			EnemyItemSpawn.spawnItem = false;
                    testupdate = true;
                }
                if(testupdate == true){
                Destroy(gameObject);
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
                EnemySprite.color = new Color(255, 0, 0, 255);
            }
            else if (flashCounter < 0){
                EnemySprite.color = new Color(255, 255, 255, 255);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }
}
