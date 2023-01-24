using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class playercontrol : MonoBehaviour
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
    public LayerMask isGroundedLayer;
    public float groundCheckRadius;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        if (speed <= 0)
        {
            speed = 6.0f;
            Debug.Log("Speed was set incorrect, defaulting to" + speed.ToString());
        }
        
        if (jumpForce <= 0)
        {
            jumpForce = 300;
            Debug.Log("jump force was set incorrect, defaulting to " + jumpForce.ToString());
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
            Debug.Log("Gound Check not set, finding it manually!");
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
        float hinput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundedLayer);

        if (isGrounded && Input.GetButtonDown("jump")) 
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        Vector2 moveDirection = new Vector2(hinput * speed, rb.velocity.y);
        rb.velocity = moveDirection;

        anim.SetFloat("hinput", Mathf.Abs(hinput));
        anim.SetBool("isGrounded", isGrounded);


        Debug.Log(hinput);
    }
}