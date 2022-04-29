using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMain : MonoBehaviour
{
    public GameObject panel;
    public GameObject pauseMenu;

    void Start()
    {
        panel.gameObject.SetActive(false);
    }

  public void OpenPanel()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(true);
        }
    }

   public void ClosePausePanel()
    {
        if (pauseMenu != null)
        {
            bool isActive = pauseMenu.activeSelf;
            pauseMenu.SetActive(false);
        }
    }
}
