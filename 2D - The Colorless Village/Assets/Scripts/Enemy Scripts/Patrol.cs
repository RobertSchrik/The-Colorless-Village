using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour{

    public float speed;
    public float distance;

    private bool animationtime;
    private bool moveRight = true;

    public Transform GroundDetection;

    public Animator animator;

    // Update is called once per frame
    void Update(){
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false || groundInfo.collider.gameObject.tag == "WallCollision"){
            if (moveRight == true){
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = false;
            }
            else{
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            animator.SetBool("InRange", true);
            speed = 0f;
        } 
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            animator.SetBool("InRange", false);
            speed = 2f;
        }
    }

}
