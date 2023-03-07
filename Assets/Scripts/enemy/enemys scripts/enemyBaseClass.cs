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
    protected int _heath;
    public float groundCheckRadius;
    public Transform groundCheck;
    public bool isGrounded;
    public float speed;
    public float minDist = 1f;
    public List<Transform> points;
    public int nextID;
    int idChangeValue = 1;
    public float range;
    public Transform Target;
    public GameObject player;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        if (maxHeath <= 0)
            maxHeath = 5;
        heath = maxHeath;
      //  Init();
      //  MoveToNextPoint();

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
    public int heath   
    {
        get => heath;
        set
        {
            _heath = value;

            if (_heath > maxHeath)
                _heath = maxHeath;

            if (_heath <= 0)
                Death();
        }
    }


    private void Reset()
    {
        Init();
    }
    void Init()
    {
       
        GameObject root = new GameObject(name + "_root");
        root.transform.position = transform.position;
        transform.SetParent(root.transform);
        GameObject waypoint = new GameObject("Waypoints");
        waypoint.transform.SetParent(root.transform);
        waypoint.transform.position = root.transform.position;

        GameObject p1 = new GameObject("point1"); p1.transform.SetParent(waypoint.transform); p1.transform.position = Vector3.zero;
        GameObject p2 = new GameObject("point2"); p2.transform.SetParent(waypoint.transform); p2.transform.position = Vector3.zero;
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);

    }


    private void Update()
    {
        MoveToNextPoint();
    }
    void MoveToNextPoint()
    {
        Transform goalPoint = points[nextID];
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1,1,1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position,goalPoint.position)<1f)
        {
            if (nextID == points.Count - 1)
                idChangeValue = 1;

            if (nextID == 0)
                idChangeValue = 1;

            nextID += idChangeValue;
        }
    }

    public virtual void Death()
    {
        anim.SetTrigger("death");
    }
    



    public virtual void TakeDamage(int damage)
    {
        heath -= damage;
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
