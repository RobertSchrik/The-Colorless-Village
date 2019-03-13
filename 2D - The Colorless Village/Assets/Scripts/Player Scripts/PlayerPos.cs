using UnityEngine;


public class PlayerPos : MonoBehaviour {

    private GameMaster gm;

    //Set player position to last checkpoint reached
    void Start () {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckpointPos;

    }

}
