using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    //instances
    public GameObject PauseMenu;

    void Start()
    {
        gameObject.SetActive(false);
    }
   
     public void PauseGame()
    {
        //Menu enabled
        PauseMenu.SetActive(true);
        //Pausing the game using the time scale
        Time.timeScale = 0;
        //Menu enabled
        gameObject.SetActive(true);
        //Setting audio volumes to zero
        AudioListener.volume = 0;
    }

     
    public void ResumeGame()
    {
       //Menu disabled
        PauseMenu.SetActive(false);
        //Resuming form the same position
        Time.timeScale = 1;
        //Enabling the audio volume
        AudioListener.volume = 1;

    }


    public void RestartGame()
    {
        //Reloading the scene again for restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Calling the resume method.
        ResumeGame();
    }

    public void QuitGame()
    {
        //Quitting the game/application
        Application.Quit();
    }
}
