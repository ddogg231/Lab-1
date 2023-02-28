using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tank : MonoBehaviour
{
    public Transform Target;

    public float range;

    bool Detected = false;

    Vector2 Direction;
    public GameObject  Gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Vector2 targetpos = Target.position;
        Direction = targetpos - (Vector2)transform.position;

        RaycastHit2D rayinfo = Physics2D.Raycast(transform.position,Direction,range);

        if(rayinfo)
        {
            if (rayinfo.collider.gameObject.tag == "Player")
            {
                if(Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if(Detected == true)
                {
                    Detected = false;
                }
            } 
        }

        if(Detected)
        {
            Gun.transform.right = Direction;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}


