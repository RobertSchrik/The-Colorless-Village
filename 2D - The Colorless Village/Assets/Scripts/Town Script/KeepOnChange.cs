using UnityEngine;

public class KeepOnChange : MonoBehaviour
{
    //Save item on Scene change
    private void Awake(){
        DontDestroyOnLoad(this);

        //Destroy dublicate objects
        if (FindObjectsOfType(GetType()).Length > 1){
            Destroy(gameObject);
        }
    }
}
