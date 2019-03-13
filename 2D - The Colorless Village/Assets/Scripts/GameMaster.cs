using UnityEngine;

public class GameMaster : MonoBehaviour {

    private static GameMaster instance;

    //Last checkpoint reached by player
    public Vector2 lastCheckpointPos;

    //Creates bug machine
    private void Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(instance);
        } else{
            Destroy(gameObject);
        }
    }
}
