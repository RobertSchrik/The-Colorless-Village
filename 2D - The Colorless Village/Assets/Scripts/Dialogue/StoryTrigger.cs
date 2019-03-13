using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour {

    public Story story;

    public void StoryManager()  {
        FindObjectOfType<StoryManager>().StartStory(story);
    }
}
