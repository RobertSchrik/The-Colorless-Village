using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToBoss : MonoBehaviour {

    public bool PlayerInRange;
    public GameObject TextPopup;

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Return) && PlayerInRange){
            SceneManager.LoadScene(0);
        }

        if (PlayerInRange){
            TextPopup.SetActive(true);
        }
    }

    //Set PlayerInRange true if player is within map radius
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "player"){
            PlayerInRange = true;
        }
    }

    //Set PlayerInRange true if player leaves map radius
    void OnTriggerExit2D(Collider2D other){
        if (other.name == "player"){
            PlayerInRange = false;
            TextPopup.SetActive(false);
        }
    }
}
