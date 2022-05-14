using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controll : MonoBehaviour
{
   
    private Transform target;
    private Vector3 startOffset;
    private Vector3 moveVector;

   

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = target.position + startOffset;

        //X
        moveVector.x = 0;

        //y
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);


        
            transform.position = target.position + startOffset;
        
       
    }

}
