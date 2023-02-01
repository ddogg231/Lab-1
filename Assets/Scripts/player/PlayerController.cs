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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        if(curPlayingClip.Length > 0)
        {
            if (Input.GetButtonDown("Fire") && curPlayingClip[0].clip.name != "Fire")
            {
                anim.SetTrigger("isShooting");
            }
            else if ((curPlayingClip[0].clip.name == "Fire"))
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

        if(!isGrounded && Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("shooting up");
        }
       
       // Vector2 moveDirection = new Vector2(hinput * speed, rb.velocity.y);
       // rb.velocity = moveDirection;

        anim.SetFloat("hinput", Mathf.Abs(hinput));
        anim.SetBool("isGrounded", isGrounded);

        //Check for flipped and create an algorithm to flip character
            if (hinput > 0 && sr.flipX || hinput < 0 && !sr.flipX)
            sr.flipX = !sr.flipX;
     
    }
}
