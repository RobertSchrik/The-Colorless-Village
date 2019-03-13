using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImunityParticles : MonoBehaviour {

	public Player_Movement player;

	public float timer;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player_Movement> ();

		gameObject.GetComponent<ParticleSystem>().Stop();
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null)
        {
            return;
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.y);

            if (Player_DamageTaken.shieldActive == true && PotionOfShield.shield == true)
            {
                gameObject.GetComponent<ParticleSystem>().Play();
                timer = 5;
                PotionOfShield.shield = false;
            }
            if (Player_DamageTaken.shieldActive == false)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    gameObject.GetComponent<ParticleSystem>().Stop();
                    DrinkingPotions.maxActivePotions = DrinkingPotions.maxActivePotions - 1;
                }
            }
        }
	}
}