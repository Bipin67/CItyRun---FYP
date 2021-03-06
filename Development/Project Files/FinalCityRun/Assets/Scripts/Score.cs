using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0.0f;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 20;
    private int scoreToNextLevel = 20;
    public Text scoreText;
    private bool isDead = false;
    public Death_Menu deathMenu;


    // Update is called once per frame
    void Update()
    {

        if (isDead)
        {
            return;
        }

        if (score >= scoreToNextLevel)
        {
            LevelUp();
        }

        score += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)score).ToString();
    }

    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
        {
            return;
        }
        scoreToNextLevel *= 2;
        difficultyLevel++;
        GetComponent<Player_Controller>().SetSpeed(difficultyLevel);
        Debug.Log(difficultyLevel);
    }

    public void OnDeath()
    {
        isDead = true;
        PlayerPrefs.SetFloat("HighScore", score);
        deathMenu.ToggleEndMenu(score);
    }
}
