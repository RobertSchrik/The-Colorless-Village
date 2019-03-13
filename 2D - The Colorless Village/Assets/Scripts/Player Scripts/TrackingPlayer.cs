using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackingPlayer : MonoBehaviour{
    //Camera position change x 
    [SerializeField]
    float xOffset;

    //Camera position change y 
    [SerializeField]
    float yOffset;

    //Track object
    [SerializeField]
    protected Transform trackingTarget;

    //Text | You died
    [SerializeField]
    public GameObject PlayerDeathText;

    //Reloads level if player is gone
    void Update(){
    
        //If player is gone start restart process and show text if player is back to life disable text
        if (trackingTarget == null){
            StartCoroutine(HandleIt());
            PlayerDeathText.SetActive(true);
            return;
        }else if (trackingTarget != null){
            PlayerDeathText.SetActive(false);
        }

        //Track object
        transform.position = new Vector3(trackingTarget.position.x + xOffset,
            trackingTarget.position.y + yOffset, transform.position.z);
    }

    //Restart level after 3 seconds
    private IEnumerator HandleIt(){
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}