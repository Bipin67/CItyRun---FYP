using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageChanger : MonoBehaviour
{
    public Image original;
    public Sprite newImage;

    public void NewImg()
    {
        original.sprite = newImage;
    }
}
