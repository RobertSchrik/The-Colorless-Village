using UnityEngine;
using UnityEngine.UI;

public class Player_DamageTaken : MonoBehaviour {
    //Health
    [SerializeField]
    [Range(0, 100)]
    private float StartHealth = 0;
    public static float Health = 100;

    //Defence
    [SerializeField]
    [Range(5, 20)]
    public static int Armor = 5;
    public static bool shieldActive;
    public static float activeTime;

    //Dps
    [SerializeField]
    [Range(0, 100)]
    int AttackDamage = 50;

    //Hitforce - armor
    int DamageTaken = 0;

    //Healthbar 
    [SerializeField]
    public Image Healthbar;

    private bool Invincibility = false;
    public Text health_text;
    public Text damage_text;
    public Text defence_text;

    //Health equal to start health
    void Start(){
        StartHealth = Health;
        health_text.text = "Health: " + Health + "/" + StartHealth;
        damage_text.text = "Defence: " + Armor;
        defence_text.text = "Attack: " + AttackDamage;
        shieldActive = false;
    }

    void Update(){
        if (Health <= 0){
            Health = 100;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        if (HealthPotion.healingItem == true) {
            //Change healthbar when healing item has been drunk
            Healthbar.fillAmount = Health / 100f;
            health_text.text = "Health: " + Health + "/" + StartHealth;
            HealthPotion.healingItem = false;
        }
        if (GreaterHealthParticles.particleTimer >= 0) {
            //Change healthbar when healing item has been drunk
            Healthbar.fillAmount = Health / 100f;
            health_text.text = "Health: " + Health + "/" + StartHealth;
            GreaterPotionOfHealth.healingItem = false;
        }
        if (PotionOfLifeSteal.healingItem == true) {
            //Change healthbar when healing item has been drunk
            Healthbar.fillAmount = Health / 100f;
            PotionOfLifeSteal.healingItem = false;
        }
        if (PotionOfRegeneration.healingItem == true) {
            //Change healthbar when healing item has been drunk
            Healthbar.fillAmount = Health / 100f;
            if (PotionOfRegeneration.potionTimer <= 0) {
                PotionOfRegeneration.healingItem = false;
            }
        }
    }

    //Spike Trap
    private void OnTriggerStay2D(Collider2D other){
        //If invincibility = false trap deals damage
        if (!Invincibility){
            if (other.gameObject.CompareTag("Trap")){
                AttackDamage = 110;
                DamageTaken = AttackDamage - Armor;
                Health -= DamageTaken;

                //Set invincibility = true for 2 seconds
                Invincibility = true;
                Invoke("InvincibilityTimer", 0);

                //Change healthbar when damage has been done
                Healthbar.fillAmount = Health / 100f;
                health_text.text = "Health: " + Health + "/" + StartHealth;
            }
            if (other.gameObject.CompareTag("Enemy") && shieldActive == false){
                AttackDamage = 20;
                DamageTaken = AttackDamage - Armor;
                Health -= DamageTaken;

                //Set invincibility = true for 2 seconds
                Invincibility = true;
                Invoke("InvincibilityTimer", 1);

                //Change healthbar to damage done
                Healthbar.fillAmount = Health / 100f;
                health_text.text = "Health: " + Health + "/" + StartHealth;
            }
            if (other.gameObject.CompareTag("Enemy") && shieldActive == true){
                if (activeTime > 0) {
                    activeTime -= Time.deltaTime;
                    if (activeTime <= 0) {
                        shieldActive = false;
                    }
                }
            }
        }
    }

    //Invinicility countdown timer
    void InvincibilityTimer(){
        Invincibility = false;
    }
}
