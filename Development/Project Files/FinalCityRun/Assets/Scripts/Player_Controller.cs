using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    // instances
    private CharacterController _controller;
    private Vector3 _moveVector;
    private Animator _anim;
    private bool _isDead;

    public float speed ;
    private float _verticalVelocity = 0.5f;
    private float gravity = 12.0f;

    public AudioSource MainTheme;
    public AudioSource coinSound;
    public float coin = 0;
    public Text coinCount;
    public Text coinCount2;
    public AudioSource GameOverSound;
    public bool jump = false;
    public bool slide = false;
    public bool horizontalMovement = false;
    public bool Moveright = false;

    //On test 2
    private float _bostertimer;
    private bool _isBoosting;//
    

    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
        MainTheme.Play();
    }

    // Update is called once per frame
    void Update()
    {
        coinCount.text = coin.ToString();
        coinCount2.text = coin.ToString();
        
        //On test 2
        if (_isBoosting)
        {
            _bostertimer += Time.deltaTime;
            if (_bostertimer >= 3)
            {
                _isBoosting = false;
                _bostertimer = 0;
                speed = 15.0f;
            }
        }//
    
        if (_isDead)
        {
            return;
        }

        _moveVector = Vector3.zero;

        // check if the player is grounded
        if (_controller.isGrounded)
        {
            _verticalVelocity = -0.5f;
        }
        else
        {
            _verticalVelocity -= gravity * Time.deltaTime;
        }

        // x - left and right
        _moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        
        // //for mobile divices
        // if (Input.GetMouseButton(0))
        // {
        //     if (Input.mousePosition.x < Screen.width / 4 )
        //     {
        //         moveVector.x = -speed;
        //     }
        //     else
        //     {
        //         moveVector.x = speed;
        //     }
        // }
        
       
        
        switch (horizontalMovement)
        {
            //button movement
            case true when Moveright:
                _moveVector.x = speed;
                Debug.Log("Right CLicked");
                
                break;
            case true when !Moveright:
                _moveVector.x = -speed;
                Debug.Log("Left CLicked");
                break;
        }

        //Player Jump activation 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if(jump)
        {
            StartCoroutine(StartJump(callback =>
            {
                if (callback)
                {
                    jump = false;
                    Debug.Log("i called you back");
                    _anim.SetBool("isJump", false);  
                }
                
            }));
        }
        
        else if (!jump)
        {
            _anim.SetBool("isJump", false);
        }


         //Player Slide  activation 
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            slide = true;
        }

        if(slide)
        {
            StartCoroutine(StartSLide(callback =>
            {
                if (callback)
                {
                    slide = false;
                    Debug.Log("i called you back");
                    _anim.SetBool("isSlide", false);  
                }
            }));
        }
        
        else if (!slide)
        {
            _anim.SetBool("isSlide", false);
        }

        

        // z -  Forward and backward
        _moveVector.z = speed;
        //move forward
        _controller.Move(_moveVector * Time.deltaTime); 
     
    }

    public void SetSpeed(float modifier)
    {
        speed = 15.0f + modifier;
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // if the player hits an obstacle
        if (hit.transform.tag == "Obstacle" && !_isDead)
        {
            Death();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // if the player hits a coin
        if (other.transform.tag == "Coin")
        {
            Destroy(other.gameObject, 0.1f);
            coinSound.Play();
            coin += 1f;
        }
        // if the player hits a booster
        if (other.tag == "Booster")
        {
            _isBoosting = true;
            speed = 35.0f;
            Destroy(other.gameObject, 0.1f);
            coinSound.Play();
            // coin += 1f;
        }//

    }

    private void Death()
    {
        // destroy the obstacle
        _isDead = true;
        _anim.SetTrigger("death");
        MainTheme.Stop();
        GameOverSound.Play();
        GetComponent<Score>().OnDeath();
    }
    public void RestartGame()
    {
        //reload the scene
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void ClickedOnMovement(bool clicked)
    {
        horizontalMovement = clicked;
    }

    public void MoveRight(bool right)
    {
        Moveright = right;
        
    }

    public void JumpButton()
    {
        jump = true;
    }
    
    public void SlideButton()
    {
        slide = true;
    }

    private IEnumerator StartJump( Action<bool> callback)
    {
        Debug.Log(" i am inside you");
        _anim.SetBool("isJump", true);
        
        yield return new WaitForSeconds(.25f);
        callback(true);
    }
    
    private IEnumerator StartSLide( Action<bool> callback)
    {
        Debug.Log(" i am inside you");
        _anim.SetBool("isSlide", true);
        
        yield return new WaitForSeconds(.25f);
        callback(true);
    }

}
