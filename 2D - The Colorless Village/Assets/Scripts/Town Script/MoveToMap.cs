using UnityEngine;

public class MoveToMap : MonoBehaviour {

    //Check for player to access map
    public bool PlayerInRange;
    public GameObject TextPopup;

    //Map map
    public GameObject Map;

    //Player in map range is false
    void Start () {
        PlayerInRange = false;
	}
	
    //On [enter] open map
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return) && PlayerInRange){
            Map.SetActive(true);
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
            Map.SetActive(false);
            TextPopup.SetActive(false);
        }
    }
}
