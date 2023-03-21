using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBaseClass : MonoBehaviour
{
    public LayerMask isGroundLayer;
    protected Rigidbody2D rb;
    protected SpriteRenderer sr;
    protected Animator anim;
    public int maxHeath;
    protected int heath;

    //ground check and movement
    public float groundCheckRadius;
    public Transform groundCheck;
    public bool isGrounded;
    public float speed;
    public float minDist = 1f;
    public List<Transform> points;
    public int nextID;
   // int idChangeValue = 1;

    //targetting /patrol / shooting
    public float range;
    public Transform Target;
    public GameObject player;
    audiomanager asm;

    public AudioClip Deathsound;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        asm = GetComponent<audiomanager>();
        if (maxHeath <= 0)
            maxHeath = 5;
        heath = maxHeath;




        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
            Debug.Log("Ground Check Radius was set incorrect, defaulting to " + groundCheckRadius.ToString());
        }

        if (!groundCheck)
        {
            groundCheck = GameObject.FindGameObjectWithTag("groundCheck").transform;
            Debug.Log("Ground Check not set, finding it manually!");
        }
    }

    public virtual void Death()
    {
        anim.SetTrigger("death");
        if (Deathsound)
            GameManager.Instance.playerInstance.GetComponent<audiomanager>().Playoneshot(Deathsound, false);
        Destroy(gameObject);
    }

    public virtual void TakeDamage(int damage)
    {
        heath -= damage;
        if (heath <= 0)
        {

            anim.SetTrigger("death");

            Destroy(gameObject);
        }

    }


    

    public void death()
        {
        anim.SetTrigger("death");
        }
        public void Destroyself()
    {
        Destroy(gameObject.transform.parent.gameObject.transform.parent);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
