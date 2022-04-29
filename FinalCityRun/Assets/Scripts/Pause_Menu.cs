using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{

    // public PlayerController Player;
    public GameObject PauseMenu;

    void Start()
    {
        gameObject.SetActive(false);
    }
   
     public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        gameObject.SetActive(true);
        AudioListener.volume = 0;
        Debug.Log("Game is Paused");
        // Player.enabled = false;
    }

    // Update is called once per frame
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.volume = 1;

    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResumeGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
