using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D),(typeof(Rigidbody2D)))]
public class japansesetroop : enemyBaseClass
{
    
    int idChangeValue = 1;

    public override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody2D>();
        if (speed <= 0)
            speed = 1.5f;
    }


    // Update is called once per frame
   

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
        AnimatorClipInfo[] curClips = anim.GetCurrentAnimatorClipInfo(0);
        float range = GameManager.Instance.playerInstance.transform.position.x - gameObject.transform.position.x;
        
       /*if (range < minDistance && range > -minDistance)
        {

            if (GameManager.Instance.playerInstance.transform.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }

        }*/
        /*if (curClips[0].clip.name == "running")
        {
            if (sr.flipX)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }*/
    }
    void MoveToNextPoint()
    {
        Transform goalPoint = points[nextID];
            
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            if (nextID == points.Count - 1)
                idChangeValue = -1;

            if (nextID == 0)
                idChangeValue = 1;

            nextID += idChangeValue;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barrier"))
        {
            sr.flipX = !sr.flipX;
        }    

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
       GameManager.Instance.playerInstance.lives--;
        }
        
    }
}
