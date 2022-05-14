using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class CoinCollection : MonoBehaviour
{
    public AudioSource coinSound;


    void OnTriggerEnter(Collider other)
    {
        // coinSound.Play;
        Destroy(this.gameObject);
    }
}
