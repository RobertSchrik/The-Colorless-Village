using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueStarter : MonoBehaviour {
    
    //Check for player to access map
    public bool PlayerInRange;
    public Dialogue dialogue;
    public Animator animator;
    public Transform DialogueManager;
    public GameObject TextPopup;

    //Player in map range is false
    void Start(){
        PlayerInRange = false;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Return) && PlayerInRange && animator.GetBool("IsOpen")){
            DialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && PlayerInRange){
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

        if (PlayerInRange){
            TextPopup.SetActive(true);
        }
    }

    //Set PlayerInRange true if player is within map radius
    void OnTriggerEnter2D(Collider2D other){
        if (other.name == "player"){
            PlayerInRange = true;
        }
    }

    //Set PlayerInRange true if player leaves map radius
    void OnTriggerExit2D(Collider2D other){
        if (other.name == "player"){
            PlayerInRange = false;
            animator.SetBool("IsOpen", false);
            TextPopup.SetActive(false);
        }

    }
}
