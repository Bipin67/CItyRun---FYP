using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death_Menu : MonoBehaviour
{
    //Instances
    public Image BackgroundImage;
    public Text scoreText;
    public GameObject panel;
    
    void Start()
    {
        gameObject.SetActive(false);
    }
   public void ToggleEndMenu(float score)
    {
        //enabling the game object
        gameObject.SetActive(true);
        //disabling the game object
        panel.SetActive(false);
        //converting the int value to string.
        scoreText.text = ((int)score).ToString();
    }

    public void Restart()
    {
        //Reloading the game scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        //changing the game scene to menu.
        SceneManager.LoadScene("Menu");
    }
}
