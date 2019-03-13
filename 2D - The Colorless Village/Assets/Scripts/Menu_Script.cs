using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{
    //Level load menu
    public void StateMainMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    //Level load town
    public void StatePlayGame(){
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    //Level load Ground
    public void StartGroundLevel(){
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    //Level load Fire
    public void StartFireLevel(){
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }

    //Level load Ice
    public void StartIceLevel(){
        SceneManager.LoadScene(4);
        Time.timeScale = 1f;
    }

    //Game Quit
    public void QuitGame(){
        Application.Quit();
    }
}
