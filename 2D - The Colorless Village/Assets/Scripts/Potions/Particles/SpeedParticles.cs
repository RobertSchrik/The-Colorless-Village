﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedParticles : MonoBehaviour {

	public Player_Movement player;

	public float particleTimer;

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

            if (PotionUse.speedPlusItem == true)
            {
                particleTimer = 25;
                PotionUse.speedPlusItem = false;
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