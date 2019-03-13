using UnityEngine;

public class Player_Attack : MonoBehaviour {

    //Attack cooldown/cooldown timer and animation time
    public float AttackCooldown;
    public static float AttackCooldownStart;
    private bool animationtime;

    //Attack position 
    public Transform AttackPosition;
    
    //Attack enemy only
    public LayerMask WhatIsEnemy;

    public LayerMask WhatIsChest;

    //Range of attack
    public float AttackRange;

    //Damage done
    public static int damage;

    //Animator
    public Animator animator;

    void Start () {
        
        damage = 25;
        AttackCooldownStart = 0.8f;
    }

    //Animation setup
    void Update(){
        HandleInput();
    }

    //Player attack objects with component (enemy)
    void FixedUpdate () {
        if (AttackCooldown <= 0 ){
            if (Input.GetKey(KeyCode.J)){
                animationtime = true;
                Collider2D[] DamageDoneToEnemy = Physics2D.OverlapCircleAll(AttackPosition.position, AttackRange, WhatIsEnemy);
                for (int i = 0; i < DamageDoneToEnemy.Length; i++){
                    DamageDoneToEnemy[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                Collider2D[] DamageDoneToChest = Physics2D.OverlapCircleAll(AttackPosition.position, AttackRange, WhatIsChest);
                for (int i = 0; i < DamageDoneToChest.Length; i++)
                {
                    DamageDoneToChest[i].GetComponent<Chest>().TakeDamage(damage);
                }
                AttackCooldown = AttackCooldownStart;
            }
        }
        AttackCooldown -= Time.deltaTime;
    }


    //Check if animation can be triggered
    void HandleInput(){
        if (animationtime == true){
            animator.SetTrigger("attack");
            animationtime = false;
        }
    }

    //Weapon range in color
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPosition.position, AttackRange);
    }
}
