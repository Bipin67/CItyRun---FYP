using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuQuit : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelPause;

    private void Start()
    {
        panel.gameObject.SetActive(false);
    }


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
    public void OpenPanel()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(true);
            panelPause.SetActive(true);
        }
    }
}
