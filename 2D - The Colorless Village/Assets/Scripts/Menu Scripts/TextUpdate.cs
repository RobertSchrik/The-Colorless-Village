using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour {

    public GameObject Inventoryplayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !Inventoryplayer) 
        {
            Inventoryplayer.SetActive(Inventoryplayer.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.I) && Inventoryplayer)
        {
            Inventoryplayer.SetActive(!Inventoryplayer.activeSelf);
        }
    }
}
