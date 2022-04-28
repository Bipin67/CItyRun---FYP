using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death_Menu : MonoBehaviour
{
    public Image BackgroundImage;
    public Text scoreText;
    // private bool isShown = false;
    // private float transition = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if (!isShown)
        // {
        //     return;
        //     transition += Time.deltaTime;
        //     BackgroundImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
        // }

    }

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        // isShown = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
