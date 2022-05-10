using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControls : MonoBehaviour
{
   [SerializeField] float left, right, up, down;

  public void MoveLeft()
   {
      transform.Translate(-left,0f,0f);
   }
   
  public void MoveRight()
  {
      transform.Translate(right,0f,0f);
      Debug.Log("Right btn clicked");
  }
  
  public void MoveUp()
  {
      transform.Translate(0f,0f,up);
  }
  
  public void MoveDown()
  {
      transform.Translate(0f,0f,-down);
  }
}
 