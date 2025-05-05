using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    bool isPaused;
    public GameObject pauseMenu;
    public void Update(){
        if (Input.GetButtonDown("Cancel")){
            if(isPaused){
                ResumeGame();
            }
            else {
                PauseGame();
            }

        }
    }
    public void PauseGame(){
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;
    }
    public void ResumeGame(){
        
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }
    public void RestartGame(){
        SceneManager.LoadScene("Game");
    }
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame(){
        Application.Quit();
    }
}
