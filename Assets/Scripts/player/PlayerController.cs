using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    //Components
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    //movement var
    public float speed;
    public float jumpForce;

    //groundcheck stuff
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask isGroundLayer;
    public float groundCheckRadius;
    public float isShooting;
    public float isCrouch;



//Pickup updates

    public int maxLives = 5;
    private int _lives;

    Coroutine jumpForceChange;
    Coroutine SpeedChange;

    public int lives
    {
        get { return _lives; }
        set
        {
            //if {lives > value}
            // we lost a life

            _lives = value;

            if (_lives > maxLives)
                _lives = maxLives;

            //if (_lives < 0)
            // gameover we ded

            Debug.Log("lives have been set to: " + _lives.ToString());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        if (speed <= 0)
        {
            speed = 6.0f;
            Debug.Log("Speed was set incorrect, defaulting to " + speed.ToString());
        }

        if (jumpForce <= 0)
        {
            jumpForce = 300;
            Debug.Log("Jump force was set incorrect, defaulting to " + jumpForce.ToString());
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
            Debug.Log("Ground Check Radius was set incorrect, defaulting to " + groundCheckRadius.ToString());
        }

        if (!groundCheck)
        {
            groundCheck = GameObject.FindGameObjectWithTag("GroundCheck").transform;
            Debug.Log("Ground Check not set, finding it manually!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] curPlayingClip = anim.GetCurrentAnimatorClipInfo(0);
        float hinput = Input.GetAxisRaw("Horizontal");
        bool isShooting = Input.GetButtonDown("Fire1");
        // bool isCrouching = Input.GetButtonDown("Crouching");
        bool crouch = false;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

       if (curPlayingClip.Length > 0)
        {
            if (Input.GetButtonDown("Fire1") && curPlayingClip[0].clip.name != "Fire1")
            {
                anim.SetTrigger("isShooting");
            }
            else if ((curPlayingClip[0].clip.name == "Fire1"))
            {
                rb.velocity = Vector2.zero;
            }
            else
            {
                Vector2 moveDirection = new Vector2(hinput * speed, rb.velocity.y);
                rb.velocity = moveDirection;
            }
            
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        if(Input.GetButtonDown("Vertical"))
        {
            crouch = true;
            
        }
        else if(Input.GetButtonUp("Vertical"))
        {
            crouch = false;
        }

        //if (!isGrounded && Input.GetButtonDown("Jump"))
       // {
       //     anim.SetTrigger("shooting up");
        //}

        // Vector2 moveDirection = new Vector2(hinput * speed, rb.velocity.y);
        // rb.velocity = moveDirection;

        anim.SetFloat("hinput", Mathf.Abs(hinput));
        anim.SetBool("isGrounded", isGrounded);

        //Check for flipped and create an algorithm to flip character
        if (hinput > 0 && sr.flipX || hinput < 0 && !sr.flipX)
            sr.flipX = !sr.flipX;

        //transform.Rotate(0f, 180f, 0f);
        if (isGrounded)
            rb.gravityScale = 1;

            

    }

    public void IncraseGravity()
        {
            rb.gravityScale = 3;
        }

    public void StartJumpForceChange()
    {
        if (jumpForceChange == null)
        {
            jumpForceChange = StartCoroutine(JumpForceChange());
        }
        else
        {
            StopCoroutine(jumpForceChange);
            jumpForceChange = null;
            jumpForce /= 2;
            jumpForceChange = StartCoroutine(JumpForceChange());
            
        }

    }

    IEnumerator JumpForceChange()
    {
        jumpForce *= 2;
        yield return new WaitForSeconds(5.0f);

        jumpForce /= 2;
        jumpForceChange = null;
    }
    
    public void StartSpeedChange()
    {
        if (SpeedChange == null)
        { 
            SpeedChange = StartCoroutine(speedChange());
            
        }
        else
        {
            StopCoroutine(SpeedChange);
            SpeedChange = null;
            speed /= 2;
            SpeedChange = StartCoroutine(speedChange());
        }

    }

    IEnumerator speedChange()
    {
        speed *= 2;
        yield return new WaitForSeconds(15.0f);

        speed /= 2;
        SpeedChange = null;
    }
}
