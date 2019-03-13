using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

        public static bool PauseGame = false;

    public GameObject pauseMenu;

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (PauseGame){
                Resume();
            } else{
                Pause();
            }
        }
	}

    public void Resume (){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    void Pause (){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void ReturnMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
        PauseGame = false;
    }

    public void ExitGame(){
        Application.Quit();
    }

    //Level load menu
    public void StateMainMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    //Level load town
    public void StatePlayGame(){
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    //Level load Ground
    public void StartGroundLevel(){
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    //Level load Fire
    public void StartFireLevel(){
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    //Level load Ice
    public void StartIceLevel(){
        SceneManager.LoadScene(4);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    //Game Quit
    public void QuitGame(){
        Application.Quit();
    }

}
