using UnityEngine;

public class CheckPoint : MonoBehaviour {

    private GameMaster gm;

    void Start(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    //Change checkpoint
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            gm.lastCheckpointPos = transform.position;
        }
    }
}
