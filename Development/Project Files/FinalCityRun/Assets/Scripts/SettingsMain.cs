using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SettingsMain : MonoBehaviour
{
    public GameObject panel;
    
    void Start()
    {
        //Panel disabling at start
        panel.gameObject.SetActive(false);
    }

  public void OpenPanel()
    {
        if (panel != null)
        {
            // bool isActive = panel.activeSelf;
            panel.SetActive(true); //activating the panel
            Time.timeScale = 0; //pausing the game on panel open.
            AudioListener.volume = 0; // Audio to 0 on panel open.
            
        }
    }

    public void ClosePausePanel()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(false);
            Time.timeScale = 1;
            AudioListener.volume = 1;
        }
    }
}
