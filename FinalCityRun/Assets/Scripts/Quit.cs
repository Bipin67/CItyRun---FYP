using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelPause;
    
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ClosePanel()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(false);
            panelPause.SetActive(true);
        }
    }
}
