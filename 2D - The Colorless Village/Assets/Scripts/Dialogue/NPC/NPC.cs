﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public Dialogue dialogue;

    public void DialogueManager (){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
