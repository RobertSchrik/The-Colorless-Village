using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryStarter : MonoBehaviour
{

    //Check for player to access map
    public Story story;
    public Transform StoryManager;
    public GameObject TextPopup;
    public GameObject MainMenu;

    //Player in map range is false
    void Start(){

    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Return) && MainMenu.activeSelf == false){
            StoryManager.GetComponent<StoryManager>().DisplayNextSentence();
        }
    }

}
