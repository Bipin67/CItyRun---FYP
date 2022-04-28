using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Manager : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;
    
    void update()
    {
        coinCountDisplay.GetComponent<Text>().text = "" + coinCount;
    }
   
}
