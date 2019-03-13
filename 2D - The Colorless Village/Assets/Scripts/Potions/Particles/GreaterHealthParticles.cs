using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreaterHealthParticles : MonoBehaviour {

	public Player_Movement player;

	public static float particleTimer;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player_Movement> ();

		gameObject.GetComponent<ParticleSystem>().Stop();

		particleTimer = 0;
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

            if (PotionUse.greaterHealingItem == true)
            {
                particleTimer = 0.5f;
                PotionUse.greaterHealingItem = false;
            }

            if (particleTimer > 0)
            {
                particleTimer -= Time.deltaTime;
                gameObject.GetComponent<ParticleSystem>().Play();
                if (particleTimer <= 0)
                {
                    gameObject.GetComponent<ParticleSystem>().Stop();
                }
            }
        }
	}
}