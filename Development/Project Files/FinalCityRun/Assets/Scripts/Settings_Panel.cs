using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Panel : MonoBehaviour
{
    public GameObject Panel;


    void Start()
    {
        Panel.gameObject.SetActive(false);
        Panel.SetActive(false);
    }

    public void openPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(true);
        }
    }

    public void closePanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(false);
        }
    }
   
    public void Audio_On_Off()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

}
