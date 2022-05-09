using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    // instances
    private CharacterController Controller;
    private Vector3 moveVector;
    private Animator anim;
    private bool isDead;

    public float speed = 10.0f;
    private float verticalVelocity = 0.5f;
    private float gravity = 12.0f;

    public AudioSource MainTheme;
    public AudioSource coinSound;
    public float coin = 0;
    public Text coinCount;
    public Text coinCount2;
    public AudioSource GameOverSound;
    public bool jump = false;
    public bool slide = false;

    //On test 2
    private float Bostertimer;
    private bool IsBoosting;//
    
    void Start()
    {
        Controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        MainTheme.Play();

    }

    // Update is called once per frame
    void Update()
    {
        coinCount.text = coin.ToString();
        coinCount2.text = coin.ToString();
        //On test 2
        if (IsBoosting)
        {
            Bostertimer += Time.deltaTime;
            if (Bostertimer >= 3)
            {
                IsBoosting = false;
                Bostertimer = 0;
                speed = 10.0f;
            }
        }//

        if (isDead)
        {
            return;
        }

        moveVector = Vector3.zero;

        // check if the player is grounded
        if (Controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // x - left and right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        
        //for mobile divices
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x < Screen.width / 4)
            {
                moveVector.x = -speed;
            }
            else
            {
                moveVector.x = speed;
            }
        }
       

        //Player Jump activation 
     
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        else 
        {
            jump = false;
            anim.SetBool("isJump", false);
        }

        if(jump == true)
        {
            anim.SetBool("isJump", true);
        }
        else if (jump == false)
        {
            anim.SetBool("isJump", false);
        }


         //Player Slide  activation 
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            slide = true;
        }
        else 
        {
            slide = false;
            anim.SetBool("isSlide", false);
        }

        if(slide == true)
        {
            anim.SetBool("isSlide", true);
            Controller.height = 0.5f;
            Controller.radius = 0.2f;
        }
        else if (jump == false)
        {
            anim.SetBool("isSlide", false);
        }
        

        // z -  Forward and backward
        moveVector.z = speed;
        Controller.Move(moveVector * Time.deltaTime); // move forward
    }

    public void SetSpeed(float modifier)
    {
        speed = 10.0f + modifier;
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // if the player hits an obstacle
        if (hit.transform.tag == "Obstacle" && !isDead)
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
            Controller.height = 1.76f;
            Controller.radius = 0.4f;
            coin += 1f;
        }
        // if the player hits a booster
        if (other.tag == "Booster")
        {
            IsBoosting = true;
            speed = 50.0f;
            Destroy(other.gameObject, 0.1f);
            coinSound.Play();
            coin += 1f;
        }//

    }

    private void Death()
    {
        // destroy the obstacle
        isDead = true;
        anim.SetTrigger("death");
        MainTheme.Stop();
        GameOverSound.Play();
        GetComponent<Score>().OnDeath();
    }
    public void RestartGame()
    {
        //reload the scene
        Application.LoadLevel(Application.loadedLevelName);
    }

    
}
