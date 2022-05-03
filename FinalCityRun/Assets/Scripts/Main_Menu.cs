using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public Text HighscoreText;
    void Start()
    {
        HighscoreText.text = "HighScore : " + ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
}
