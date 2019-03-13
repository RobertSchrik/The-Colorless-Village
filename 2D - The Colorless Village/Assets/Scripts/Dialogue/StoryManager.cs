using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour{
    public Text storyText;
    public Animator animator;

    private Queue<string> sentences;
    public GameObject MainMenu;

    void Start(){
        sentences = new Queue<string>();
    }

    //start dialogue
    public void StartStory(Story story){

        sentences.Clear();
        MainMenu.SetActive(false);

        foreach (string sentence in story.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndStory();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
        
    IEnumerator TypeSentence(string sentence){
        storyText.text = "";
        foreach (char letter in sentence.ToCharArray()){
            storyText.text += letter;
            yield return null;
        }
    }

    //end conversation
    void EndStory(){
        SceneManager.LoadScene(1);
    }

}
