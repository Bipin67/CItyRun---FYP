using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerUpHandler,  IPointerDownHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
       // Debug.Log("I pointer Up handler "); 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("I pointer Down handler "); 
    }
}
